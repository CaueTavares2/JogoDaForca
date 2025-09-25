// Database.cs

// Classe responsável por fornecer a string de conexão com o banco de dados MySQL.

// Ideal para projetos pequenos e ambientes de aprendizado.

// Em aplicações reais, evite deixar senhas no código-fonte!

// Use variáveis de ambiente ou Azure Key Vault em produção.

using MySql.Data;

namespace JogoDaForca

{

    public static class Database

    {

        // Propriedade estática que retorna a string de conexão.

        // Altere os valores abaixo conforme sua configuração local do MySQL.

        public static string ConnectionString

        {

            get

            {

                return "server=localhost;" + // Endereço do servidor MySQL

                "database=jogodafortuna;" + // Nome do banco de dados

                "uid=root;" + // Usuário do MySQL

                "pwd=utfpr;"; // Senha do usuário (deixe vazio se não tiver)

            }

        }

    }
}