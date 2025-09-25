// JogoDaForca.cs
// Esta classe contém a lógica principal do jogo.
// Ela é responsável por sortear a palavra, gerenciar as tentativas do usuário
// e verificar o estado do jogo (vitória ou derrota).
using JogoDaForca;
using MySql.Data.MySqlClient; // Para MySql.Data
// using MySqlConnector; // Para MySqlConnector
using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoDaForca
{
    public class JogoDaForca
    {
        // Propriedades da classe JogoDaForca
        public Palavra PalavraSorteada { get; private set; }
        public string PalavraEscondida { get; private set; }
        public List<char> LetrasTentadas { get; private set; }
        public int TentativasRestantes { get; private set; }

        // Constante para o número máximo de tentativas
        private const int MAX_TENTATIVAS = 6;

        // Construtor da classe
        public JogoDaForca()
        {
            // Inicializa a lista de letras tentadas.
            LetrasTentadas = new List<char>();

            // Define o número inicial de tentativas.
            TentativasRestantes = MAX_TENTATIVAS;
        }

        // Método para sortear uma palavra do banco de dados.
        public void SortearPalavra()
        {
            // O 'using' garante que a conexão será fechada e liberada automaticamente.
            using (var conexao = ConexaoMySQL.ObterConexao())
            {
                // Comando SQL para contar o total de palavras na tabela.
                string sqlCount = "SELECT COUNT(*) FROM palavras";
                MySqlCommand cmdCount = new MySqlCommand(sqlCount, conexao);
                int total = Convert.ToInt32(cmdCount.ExecuteScalar());

                // Verifica se há palavras no banco de dados.
                if (total == 0)
                    throw new Exception("Nenhuma palavra cadastrada no banco de dados!");

                // Sorteia um ID aleatório para a palavra.
                Random rand = new Random();
                int idSorteado = rand.Next(1, total + 1);

                // Comando SQL para selecionar a palavra com o ID sorteado.
                string sqlPalavra = "SELECT id, palavra FROM palavras WHERE id = @id";
                MySqlCommand cmdPalavra = new MySqlCommand(sqlPalavra, conexao);
                cmdPalavra.Parameters.AddWithValue("@id", idSorteado);

                // Lê o resultado da consulta.
                using (MySqlDataReader reader = cmdPalavra.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Cria um novo objeto Palavra com os dados do banco.
                        PalavraSorteada = new Palavra(reader.GetInt32("id"), reader.GetString("palavra"));
                    }
                }
            }

            // Inicializa a palavra escondida, substituindo letras por '_'.
            AtualizarPalavraEscondida();
        }

        // Método privado para atualizar a representação da palavra escondida.
        private void AtualizarPalavraEscondida()
        {
            char[] escondida = new char[PalavraSorteada.Texto.Length];
            for (int i = 0; i < PalavraSorteada.Texto.Length; i++)
            {
                // Se a letra da palavra já foi tentada, ela é revelada.
                // Caso contrário, permanece como '_'.
                escondida[i] = LetrasTentadas.Contains(PalavraSorteada.Texto[i]) ? PalavraSorteada.Texto[i] : '_';
            }
            PalavraEscondida = new string(escondida);
        }

        // Método para processar a tentativa de uma letra.
        public bool TentarLetra(char letra)
        {
            // Converte a letra para maiúscula.
            letra = char.ToUpper(letra);

            // Se a letra já foi tentada, não faz nada e retorna true para indicar que a tentativa foi válida.
            if (LetrasTentadas.Contains(letra)) return true;

            // Adiciona a letra à lista de letras tentadas.
            LetrasTentadas.Add(letra);

            // Verifica se a palavra sorteada contém a letra.
            bool acertou = PalavraSorteada.Texto.Contains(letra);

            // Se errou a letra, decrementa o número de tentativas restantes.
            if (!acertou) TentativasRestantes--;

            // Atualiza a palavra escondida com base nas novas letras tentadas.
            AtualizarPalavraEscondida();

            // Retorna se o usuário acertou a letra ou não.
            return acertou;
        }

        // Método para verificar se o jogo foi vencido.
        public bool VerificarVitoria() => !PalavraEscondida.Contains('_');

        // Método para verificar se o jogo foi perdido.
        public bool VerificarDerrota() => TentativasRestantes <= 0;
    }
}
