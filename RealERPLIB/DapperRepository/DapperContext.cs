using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealERPLIB.DapperRepository
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }
        public string GetDatabaseName()
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                return connection.Database;
            }
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
