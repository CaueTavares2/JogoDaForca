// JogoDaForca.cs
// Contém a lógica principal do jogo: sortear palavras do banco, verificar tentativas e estado do jogo.
using JogoDaForca;
using MySql.Data.MySqlClient; // Usando MySql.Data
using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoDaForca
{
    public class JogoDaForca
    {
        public Palavra PalavraSorteada { get; private set; }
        public string PalavraEscondida { get; private set; }
        public List<char> LetrasTentadas { get; private set; }
        public int TentativasRestantes { get; private set; }
        private const int MAX_TENTATIVAS = 6;

        public JogoDaForca()
        {
            LetrasTentadas = new List<char>();
            TentativasRestantes = MAX_TENTATIVAS;
        }

        public void SortearPalavra()
        {
            using (var conexao = ConexaoMySQL.ObterConexao())
            {
                string sqlCount = "SELECT COUNT(*) FROM palavras";
                MySqlCommand cmdCount = new MySqlCommand(sqlCount, conexao);
                int total = Convert.ToInt32(cmdCount.ExecuteScalar());

                if (total == 0)
                    throw new Exception("Nenhuma palavra cadastrada no banco de dados!");

                Random rand = new Random();
                int idSorteado = rand.Next(1, total + 1);

                string sqlPalavra = "SELECT id, palavra FROM palavras WHERE id = @id";
                MySqlCommand cmdPalavra = new MySqlCommand(sqlPalavra, conexao);
                cmdPalavra.Parameters.AddWithValue("@id", idSorteado);

                using (MySqlDataReader reader = cmdPalavra.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        PalavraSorteada = new Palavra(reader.GetInt32("id"), reader.GetString("palavra"));
                    }
                    else
                    {
                        reader.Close();
                        cmdPalavra.CommandText = "SELECT id, palavra FROM palavras LIMIT 1";
                        using (MySqlDataReader fallback = cmdPalavra.ExecuteReader())
                        {
                            fallback.Read();
                            PalavraSorteada = new Palavra(fallback.GetInt32("id"), fallback.GetString("palavra"));
                        }
                    }
                }
            }
            AtualizarPalavraEscondida();
        }

        // Método privado que recalcula a palavra exibida na tela.
        private void AtualizarPalavraEscondida()
        {
            char[] escondida = new char[PalavraSorteada.Texto.Length];
            for (int i = 0; i < PalavraSorteada.Texto.Length; i++)
            {
                // Verifica se a letra original já foi tentada.
                escondida[i] = LetrasTentadas.Contains(PalavraSorteada.Texto[i])
                               ? PalavraSorteada.Texto[i]
                               : '_';
            }
            // Importante: Junta os caracteres com um espaço, garantindo o espaçamento.
            PalavraEscondida = string.Join(" ", escondida);
        }

        public bool TentarLetra(char letra)
        {
            letra = char.ToUpper(letra);
            if (LetrasTentadas.Contains(letra)) return true;

            LetrasTentadas.Add(letra);

            bool acertou = PalavraSorteada.Texto.Contains(letra);

            if (!acertou) TentativasRestantes--;

            // CORREÇÃO: O nome do método deve ser AtualizarPalavraEscondida()
            AtualizarPalavraEscondida();
            return acertou;
        }

        public bool VerificarVitoria() => !PalavraEscondida.Contains('_');

        public bool VerificarDerrota() => TentativasRestantes <= 0;
    }
}
