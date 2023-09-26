using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using RealEntity.Account;
using RealEntity.Masterpage;
using RealERPLIB.DapperRepository;
using System.Data;
using static RealEntity.Masterpage.MasterClass;

namespace PTLRealERP.Pages.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterpageController : ControllerBase
    {
        private readonly IDapperService _dapperService;
        private readonly IDbConnection _dbConnection;
        public MasterpageController(IDapperService dapperService, IDbConnection dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }
        [HttpGet("ModuleData")]
        public IActionResult OnGetModule()
        {
            try
            {
                string procedureName = "SP_UTILITY_LOGIN_MGT";
                string Calltype = "GETCOMMODULE";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Calltype", Calltype);
                List<Modules> listOfModule = _dapperService.GetList<Modules>(procedureName, parameters);
                
                return Ok(new { data = listOfModule });
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return BadRequest("An error occurred while fetching ModuleData.");
            }
        }

        [HttpGet("InterfaceData")]
        public IActionResult OnGetInterface()
        {
            try
            {
                string procedureName = "SP_UTILITY_LOGIN_MGT";
                string Calltype = "GETINTERFACE";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Calltype", Calltype);
                List<Interfaces> listOfInterface = _dapperService.GetList<Interfaces>(procedureName, parameters);
                return Ok(new { data = listOfInterface });
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return BadRequest("An error occurred while fetching InterfaceData.");
            }
        }

    }
}
