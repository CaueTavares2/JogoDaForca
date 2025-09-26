// Database.cs
// Classe responsável por fornecer a string de conexão com o banco de dados MySQL.
using MySql.Data;

namespace JogoDaForca
{
    public static class Database
    {
        // Propriedade estática que retorna a string de conexão.
        public static string ConnectionString
        {
            get
            {
                // Altere a senha (pwd) conforme sua configuração local do MySQL.
                return "server=localhost;" +
                       "database=jogodafortuna;" +
                       "uid=root;" +
                       "pwd=utfpr;"; // Senha do usuário
            }
        }
    }
}