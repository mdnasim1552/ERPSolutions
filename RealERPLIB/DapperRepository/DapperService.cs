using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace RealERPLIB.DapperRepository
{
    public class DapperService:IDapperService
    {
        private readonly DapperContext _context;

        public DapperService(DapperContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            var sql = "select * from compinf";
            using (var connection = _context.CreateConnection())
            {                
                return connection.Query<User>(sql).ToList();
            }
            
        }
        public async Task<List<User>> GetAllAsync()
        {
            var sql = "select * from compinf";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<User>(sql);
                return users.ToList();
            }
           
        }
        public List<List<dynamic>> GetDataList(string procedureName, DynamicParameters parameters)
        {
            using (var connection = _context.CreateConnection())
            using (var reader = connection.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure))// Dapper.SqlMapper.GridReader
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
        public async Task<List<List<dynamic>>> GetDataListAsync(string procedureName, DynamicParameters parameters)
        {
            using (var connection = _context.CreateConnection())
            using (var reader = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure))
            {
                var resultSetList = new List<List<dynamic>>();

                while (!reader.IsConsumed)
                {
                    var resultSet = (await reader.ReadAsync<dynamic>()).ToList();
                    resultSetList.Add(resultSet);
                }
                return resultSetList;
            }
        }


        public DataSet GetDataSets(string procedureName, DynamicParameters parameters)
        {
            using (var connection = _context.CreateConnection())
            using (var reader = connection.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure))
            {
                DataSet dataSet = new DataSet();

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

                    dataSet.Tables.Add(dataTable);
                }

                return dataSet;
            }

        }
        public async Task<DataSet> GetDataSetsAsync(string procedureName, DynamicParameters parameters)
        {
            using (var connection = _context.CreateConnection())
            using (var reader = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure))
            {
                DataSet dataSet = new DataSet();

                while (!reader.IsConsumed)
                {
                    var data = await reader.ReadAsync();
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

                    dataSet.Tables.Add(dataTable);
                }

                return dataSet;
            }
        }
        public List<DataTable> GetDataTableList(string procedureName, DynamicParameters parameters)
        {
            using (var connection = _context.CreateConnection())
            using (var reader = connection.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure))
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
        public async Task<List<DataTable>> GetDataTableListAsync(string procedureName, DynamicParameters parameters)
        {
            using (var connection = _context.CreateConnection())
            using (var reader = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure))
            {
                List<DataTable> dataTables = new List<DataTable>();

                while (!reader.IsConsumed)
                {
                    var data = await reader.ReadAsync();
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
            using (var connection = _context.CreateConnection())
            using (var reader = connection.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure))
            {
                List<T> customList = reader.Read<T>().ToList();

                return customList;
            }
        }
        public async Task<List<T>> GetListAsync<T>(string procedureName, DynamicParameters parameters)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                using (var reader = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure))
                {
                    List<T> customList = (await reader.ReadAsync<T>()).ToList();
                    return customList;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error in GetListAsync: {ex.Message}");
                throw; // Re-throw the exception for higher-level handling
            }
           

            //using (var reader = await _dbConnection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure))
            //{
            //    // Read data for the specified type 'T'
            //    List<T> customList = (await reader.ReadAsync<T>()).ToList();

            //    return customList;
            //}

           
        }
        public async Task<T> GetFirstOrDefaultAsync<T>(string procedureName, DynamicParameters parameters)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryFirstOrDefaultAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetFirstOrDefaultAsync: {ex.Message}");
                throw; // Re-throw the exception for higher-level handling
            }
        }

        public (List<User> users, List<Module> mod) GetUserAndCustomerLists(string procedureName, DynamicParameters parameters)
        {
            using (var connection = _context.CreateConnection())
            using (var reader = connection.QueryMultiple(procedureName, parameters, commandType: CommandType.StoredProcedure))
            {
                // Read data for the User class
                List<User> users = reader.Read<User>().ToList();

                // Read data for the Customer class
                List<Module> mod = reader.Read<Module>().ToList();

                return (users, mod);
            }
        }
        public bool UpdateUser<T>(List<T> updatedData)
        {

            return true;
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

        public async Task<bool> ExecuteTransactionalOperationAsync(string SQLprocName, DynamicParameters parameters)
        {
            try
            {
                using (var _dbConnection = _context.CreateConnection())
                {
                    if (_dbConnection is SqlConnection sqlConnection)
                    {
                        if (_dbConnection.State != ConnectionState.Open)
                        {
                            await sqlConnection.OpenAsync();
                        }

                        using (var transaction = sqlConnection.BeginTransaction())
                        {
                            try
                            {
                                var affectedRows = await _dbConnection.ExecuteAsync(
                                    SQLprocName,
                                    parameters,
                                    commandType: CommandType.StoredProcedure,
                                    transaction: transaction,
                                    commandTimeout: 120
                                );

                                if (affectedRows > 0)
                                {
                                    // If execution was successful, commit the transaction
                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    // If no rows were affected, rollback the transaction
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                            catch (Exception exp)
                            {
                                // Handle exceptions
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> GetTransactionalOperationAsync(string SQLprocName, DynamicParameters parameters)
        {
            try
            {
                using (var _dbConnection = _context.CreateConnection())
                {
                    if (_dbConnection is SqlConnection sqlConnection)
                    {
                        if (_dbConnection.State != ConnectionState.Open)
                        {
                            await sqlConnection.OpenAsync();
                        }

                        using (var transaction = sqlConnection.BeginTransaction())
                        {
                            try
                            {
                                // Add output parameter to DynamicParameters
                                parameters.Add("@PrimaryKey", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);

                                var primaryKey = await _dbConnection.QueryFirstOrDefaultAsync<string>(
                                      SQLprocName,
                                      parameters,
                                      transaction,
                                      commandType: CommandType.StoredProcedure
                                );

                                // Execute stored procedure using Dapper
                                //var affectedRows= await _dbConnection.ExecuteAsync(SQLprocName, parameters, transaction, commandType: CommandType.StoredProcedure);

                                // Retrieve output parameter value
                                //var primaryKey = parameters.Get<string>("@PrimaryKey");

                                if (!string.IsNullOrEmpty(primaryKey))
                                {
                                    // If execution was successful, commit the transaction
                                    transaction.Commit();
                                    return primaryKey;
                                }
                                else
                                {
                                    // If no value in the output parameter, rollback the transaction
                                    transaction.Rollback();
                                    return null;
                                }
                            }
                            catch (Exception exp)
                            {
                                // Handle exceptions
                                transaction.Rollback();
                                return null;
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
