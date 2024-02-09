using Dapper;
using RealEntity.Account;
using RealERPLIB.DapperRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealERPLIB.LoginRepository
{
    public class LoginRepository:ILoginRepository
    {
        private readonly IDapperService _dapperService;
        public LoginRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<Company>> GetCompanyList()
        {
            string procedureName = "[dbo].[SP_UTILITY_LOGIN_MGT]";
            string Calltype = "COMPANYINFO";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Calltype", Calltype);
            parameters.Add("@Desc1", "%%");
            var companyList = await _dapperService.GetListAsync<Company>(procedureName, parameters);
            return companyList;
        }
        //var LoginUsers = await _dapperService.GetFirstOrDefaultAsync<LoginUsers>(procedureName, parameters);
        public async Task<Company> GetCompany(string comcod)
        {
            try
            {
                var dbName = _dapperService.GetDatabaseName();
                string procedureName = $"[{dbName}].[dbo].[SP_UTILITY_LOGIN_MGT]";
                string Calltype = "COMPANYINFO";
                comcod = "%" + comcod + "%";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Calltype", Calltype);
                parameters.Add("@Desc1", comcod);
                var comp = await _dapperService.GetSingleOrDefaultAsync<Company>(procedureName, parameters);
                return comp;
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }
        public async Task<LoginUsers> GetLoginUsers(string comcod, string username, string password)
        {
            try
            {
                var dbName = _dapperService.GetDatabaseName();
                string procedureName = $"[{dbName}].[dbo].[SP_UTILITY_LOGIN_MGT]";
                string Calltype = "LOGINUSER";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Calltype", Calltype);
                parameters.Add("@Comp1", comcod);
                parameters.Add("@Desc1", username);
                parameters.Add("@Desc2", password);
                var LoginUsers = await _dapperService.GetFirstOrDefaultAsync<LoginUsers>(procedureName, parameters);
                return LoginUsers;
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }

    }
}
