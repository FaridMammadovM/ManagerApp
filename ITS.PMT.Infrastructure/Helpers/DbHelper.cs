using Npgsql;
using System.Data;

namespace ITS.PMT.Infrastructure
{
    public class DbHelper
    {
        public static IDbConnection GetConn(string conString)
        {
            return new NpgsqlConnection(conString);
        }
    }
}