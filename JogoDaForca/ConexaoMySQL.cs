// ConexaoMySQL.cs
// Gerencia a conexão com o MySQL usando a string da classe Database.
using MySql.Data.MySqlClient;
// using MySqlConnector; // Alternativa mais moderna e recomendada.

namespace JogoDaForca
{
    public class ConexaoMySQL
    {
        // Método estático que abre e retorna uma conexão com o banco
        public static MySqlConnection ObterConexao()
        {
            // Cria uma nova conexão usando a string de conexão definida na classe Database.
            MySqlConnection conexao = new MySqlConnection(Database.ConnectionString);
            conexao.Open(); // Abre a conexão
            return conexao;
        }
    }
}