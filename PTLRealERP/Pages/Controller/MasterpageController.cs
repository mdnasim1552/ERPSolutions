using Dapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class MasterpageController : ControllerBase
    {
        private readonly IDapperService _dapperService;
        public MasterpageController(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }
        [HttpGet("ModuleData")]
        public async Task<IActionResult> OnGetModule()
        {
            try
            {
                string procedureName = "SP_UTILITY_LOGIN_MGT";
                string Calltype = "GETCOMMODULE";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Calltype", Calltype);
                List<Modules> listOfModule =await _dapperService.GetListAsync<Modules>(procedureName, parameters);
                
                return Ok(new { data = listOfModule });
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return BadRequest("An error occurred while fetching ModuleData.");
            }
        }

        [HttpGet("InterfaceData")]
        public async Task<IActionResult> OnGetInterface()
        {
            try
            {
                string procedureName = "SP_UTILITY_LOGIN_MGT";
                string Calltype = "GETINTERFACE";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Calltype", Calltype);
                List<Interfaces> listOfInterface =await _dapperService.GetListAsync<Interfaces>(procedureName, parameters);
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
