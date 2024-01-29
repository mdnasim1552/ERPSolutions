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
        public UserLoginfrmModel(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }
        public void OnGet()
        {
            
        }
        
      

    }
}
