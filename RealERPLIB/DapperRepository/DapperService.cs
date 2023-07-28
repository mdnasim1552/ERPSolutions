using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RealERPLIB.DapperRepository
{
    public class DapperService:IDapperService
    {
        private readonly IDbConnection _dbConnection;

        public DapperService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public List<User> GetAll()
        {
            var sql = "select * from compinf";
            return _dbConnection.Query<User>(sql).ToList();
        }
        public List<List<dynamic>> GetDataList(string procedureName, DynamicParameters parameters)
        {
            using (var reader = _dbConnection.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure))// Dapper.SqlMapper.GridReader
            {
                var resultSetList = new List<List<dynamic>>();
                
                while (!reader.IsConsumed)
                {
                    var resultSet = reader.Read<dynamic>().ToList();
                    resultSetList.Add(resultSet);
                }
                return resultSetList;
                
            }
        }
        public List<DataTable> GetDataTableList(string procedureName, DynamicParameters parameters)
        {
            using (var reader = _dbConnection.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure))
            {
                List<DataTable> dataTables = new List<DataTable>();

                while (!reader.IsConsumed)
                {
                    var data = reader.Read();
                    var dataTable = new DataTable();

                    // Create DataTable columns based on the dynamic property names and their types
                    if (data.Any())
                    {
                        var dynamicProperties = (IDictionary<string, object>)data.First();
                        foreach (var propertyName in dynamicProperties.Keys)
                        {
                            var propertyType = dynamicProperties[propertyName]?.GetType() ?? typeof(object);
                            dataTable.Columns.Add(propertyName, propertyType);
                        }
                    }

                    // Read data from the IEnumerable<dynamic> and load it into the DataTable
                    foreach (var item in data)
                    {
                        var dataRow = dataTable.NewRow();
                        var dynamicItem = (IDictionary<string, object>)item;
                        foreach (var propertyName in dynamicItem.Keys)
                        {
                            dataRow[propertyName] = dynamicItem[propertyName];
                        }
                        dataTable.Rows.Add(dataRow);
                    }

                    dataTables.Add(dataTable);
                }

                return dataTables;
            }

        }
        public List<T> GetList<T>(string procedureName, DynamicParameters parameters)
        {
            using (var reader = _dbConnection.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure))
            {
                // Read data for the specified type 'T'
                List<T> customList = reader.Read<T>().ToList();

                return customList;
            }
        }
        public (List<User> users, List<Module> mod) GetUserAndCustomerLists(string procedureName, DynamicParameters parameters)
        {
            using (var reader = _dbConnection.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure))
            {
                // Read data for the User class
                List<User> users = reader.Read<User>().ToList();

                // Read data for the Customer class
                List<Module> mod = reader.Read<Module>().ToList();

                return (users, mod);
            }
        }
        public class User
        {
            public string comcod { get; set; }
            public string comnam { get; set; }
        }
        public class Module
        {
            public string moduleid { get; set; }//MODULEID
            public string modulename { get; set; }//MODULENAME
        }
    }
}
