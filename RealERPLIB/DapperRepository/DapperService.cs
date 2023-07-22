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
            using (var reader = _dbConnection.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure))// Dapper.SqlMapper.GridReader
            {
                //var firstResultSet = reader.Read<dynamic>().ToList();

                var resultSetList = new List<List<dynamic>>();

                // Read each result set in a loop
                while (!reader.IsConsumed)
                {
                    var resultSet = reader.Read<dynamic>().ToList();
                    resultSetList.Add(resultSet);
                }



                //foreach (var result in firstResultSet)
                //{
                //    var nameValue = result.COMNAM; // Access the 'Name' property dynamically
                //                                 // Do something with the 'nameValue'
                //}

                

                List<DataTable> dataTables = new List<DataTable>();

                //while (!reader.IsConsumed)
                //{
                //    var List = reader.Read();
                //    DataTable dataTable = new DataTable();
                //    dataTable.Load((DataTable)List);
                //    dataTables.Add(dataTable);
                //}

                //// Read all result sets into DataTables and add them to the list
                //while (!reader.IsConsumed)
                //{
                //    dataTables.Add(reader.Read<DataTable>().FirstOrDefault());
                //}
                return dataTables;
                // Now you have a list of DataTables (dataTables) representing all the result sets.
            }
            
        }
        public class User
        {
            public string comcod { get; set; }
            public string comnam { get; set; }
        }
    }
}
