// ConexaoMySQL.cs
// Esta classe estática gerencia a conexão com o banco de dados MySQL.
// O uso de uma classe separada para a conexão é uma boa prática
// para isolar a lógica de acesso a dados.

// É necessário instalar o pacote MySql.Data ou MySqlConnector via NuGet.
using MySql.Data.MySqlClient;
// using MySqlConnector; // Alternativa mais moderna e recomendada.

namespace JogoDaForca
{
    public class ConexaoMySQL
    {
        // Método estático para obter uma conexão aberta com o banco de dados.
        // O uso de 'static' permite que o método seja chamado diretamente, sem precisar
        // instanciar a classe ConexaoMySQL.
        public static MySqlConnection ObterConexao()
        {
            // Cria uma nova conexão usando a string de conexão definida na classe Database.
            MySqlConnection conexao = new MySqlConnection(Database.ConnectionString);

            // Abre a conexão com o banco de dados.
            conexao.Open();

            // Retorna a conexão aberta.
            return conexao;
        }
    }
}
