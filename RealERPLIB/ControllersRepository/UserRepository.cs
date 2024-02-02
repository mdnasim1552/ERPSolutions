using Dapper;
using Newtonsoft.Json;
using RealEntity.Account;
using RealERPLIB.DapperRepository;
using RealERPLIB.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealERPLIB.ControllersRepository
{
    public class UserRepository:IUserRepository
    {
        private readonly IDapperService _dapperService;
        public UserRepository(IDapperService dapperService)
        {
             _dapperService = dapperService;
        }
        public async Task<List<Userinf>> GetUserList()
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "SHOWUSER";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Calltype", Calltype);
            var userList = await _dapperService.GetListAsync<Userinf>(procedureName, parameters);
            return userList;
        }
        public async Task<bool> InsertUserData(Userinf user)
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "INSERTUSER";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Calltype", Calltype);
            parameters.Add("@Comp1", user.comcod);
            parameters.Add("@Desc1", user.usrsname);
            parameters.Add("@Desc2", user.usrname);
            parameters.Add("@Desc3", user.usrdesig);
            parameters.Add("@Desc4", user.usractive);
            parameters.Add("@Desc5", ASTUtility.EncodePassword(user.usrpass));// ASTUtility.EncodePassword(Credential.Password)
            parameters.Add("@Desc6", user.mailid);
            parameters.Add("@Desc7", user.userrole);
            parameters.Add("@Desc8", user.usrid);
            parameters.Add("@Desc9", user.empid);
            //_dbConnection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
            //string result = await _dapperService.GetTransactionalOperationAsync(procedureName, parameters);

            bool result = await _dapperService.ExecuteTransactionalOperationAsync(procedureName, parameters);
            return result;
        }

        public async Task<bool> UpdateUserData(List<Userinf> updatedData)
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "UPDATEUSER";

            foreach (var user in updatedData)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Calltype", Calltype);
                parameters.Add("@Comp1", user.comcod);
                parameters.Add("@Desc1", user.usrsname);
                parameters.Add("@Desc2", user.usrname);
                parameters.Add("@Desc3", user.usrdesig);
                parameters.Add("@Desc4", user.usractive);
                parameters.Add("@Desc5", user.usrpass);
                parameters.Add("@Desc6", user.mailid);
                parameters.Add("@Desc7", user.userrole);
                parameters.Add("@Desc8", user.usrid);

                bool result = await _dapperService.ExecuteTransactionalOperationAsync(procedureName, parameters);
                if (!result)
                {
                    return false;
                }

                // _dbConnection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }


            return true;
        }

        public async Task<bool> DeleteUserData(string comcod, string usrid)
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "DELETEUSER";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Calltype", Calltype);
            parameters.Add("@Comp1", comcod);
            parameters.Add("@Desc8", usrid);

            bool result = await _dapperService.ExecuteTransactionalOperationAsync(procedureName, parameters);
            if (!result)
            {
                return false;
            }
            return true;
        }

    }
}
