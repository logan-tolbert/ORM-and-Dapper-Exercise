using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;

namespace DataAccessLibrary
{
    public class DataConfiguration
    {
        public string GetServerConfiguration()
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            string? connString = config.GetConnectionString("DefaultConnection");
            return connString;
        }
        public  DapperDepartmentRepo GetDepartmentRepo(string connString)
        {
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepo(conn);
            return repo;
        }

        public DapperProductRepo GetProductRepo(string connString)
        {
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperProductRepo(conn);
            return repo;
        }
    }
}
