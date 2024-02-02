using Dapper;
using RealEntity.Account;
using RealERPLIB.DapperRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealERPLIB.ConfigurationRepository
{
    public class RoleService:IRoleService
    {
        private readonly IDapperService _dapperService;
        public RoleService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }
        public List<UserRole> GetRoles()
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "GETUSERROLE";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Calltype", Calltype);
            var roles = _dapperService.GetList<UserRole>(procedureName, parameters);
            return roles;
        }
    }
}
