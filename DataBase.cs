using MySql.Data.MySqlClient;

namespace BankingAppForms
{
    public static class Database
    {
        private const string ConnectionString = "Server=localhost;Database=BankingApp;User ID=root;Password=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
