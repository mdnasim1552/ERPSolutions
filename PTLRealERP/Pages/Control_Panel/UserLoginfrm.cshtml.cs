using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RealEntity.Account;
using RealERPLIB.DapperRepository;
using System.Data.SqlClient;

namespace PTLRealERP.Pages.Account
{
    [Authorize]
    public class UserLoginfrmModel : PageModel
    {
        private readonly IDapperService _dapperService;
        public List<UserRole> Roles =new List<UserRole>();
        public UserLoginfrmModel(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task OnGet()
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "GETUSERROLE";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Calltype", Calltype);
            Roles =await _dapperService.GetListAsync<UserRole>(procedureName, parameters);
        }
        
      

    }
}
