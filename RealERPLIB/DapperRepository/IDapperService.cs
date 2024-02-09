using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RealERPLIB.DapperRepository.DapperService;

namespace RealERPLIB.DapperRepository
{
    public interface IDapperService
    {
        string GetDatabaseName();
        List<User> GetAll();
        Task<List<User>> GetAllAsync();
        List<DataTable> GetDataTableList(string procedureName, DynamicParameters parameters);
        Task<List<DataTable>> GetDataTableListAsync(string procedureName, DynamicParameters parameters);
        List<List<dynamic>> GetDataList(string procedureName, DynamicParameters parameters);
        Task<List<List<dynamic>>> GetDataListAsync(string procedureName, DynamicParameters parameters);
        (List<User> users, List<Module> mod) GetUserAndCustomerLists(string procedureName, DynamicParameters parameters);
        List<T> GetList<T>(string procedureName, DynamicParameters parameters);
        Task<List<T>> GetListAsync<T>(string procedureName, DynamicParameters parameters);
        Task<T> GetFirstOrDefaultAsync<T>(string procedureName, DynamicParameters parameters);
        Task<T> GetSingleOrDefaultAsync<T>(string procedureName, DynamicParameters parameters);
        DataSet GetDataSets(string procedureName, DynamicParameters parameters);
        Task<DataSet> GetDataSetsAsync(string procedureName, DynamicParameters parameters);
        Task<bool> ExecuteTransactionalOperationAsync(string SQLprocName, DynamicParameters parameters);
        Task<string> GetTransactionalOperationAsync(string SQLprocName, DynamicParameters parameters);
    }
}
