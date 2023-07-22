using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RealERPLIB.DapperRepository.DapperService;

namespace RealERPLIB.DapperRepository
{
    public interface IDapperService
    {
        List<User> GetAll();
        List<DataTable> GetDataTableList(string procedureName, DynamicParameters parameters);
        List<List<dynamic>> GetDataList(string procedureName, DynamicParameters parameters);
    }
}
