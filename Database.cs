using Npgsql;

namespace GP_1
{
    internal static class Database
    {
        internal const string ConnectionString = "Server=localhost;Port=5432;Database=income_expense_db;User Id=postgres;Password=Deep@1710;";

        internal static NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
