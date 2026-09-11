using Npgsql;

namespace GP_1
{
    internal static class Database
    {
        internal const string ConnectionString = "Server=localhost;Port=5432;Database=MoneyMap;User Id=postgres;Password=password;";

        internal static NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
