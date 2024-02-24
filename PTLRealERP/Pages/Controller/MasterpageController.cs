using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using RealEntity.Account;
using RealEntity.Masterpage;
using RealERPLIB.ControllersRepository.MasterpageControllerRepository;
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
        private readonly IMasterpageRepository _masterpageRepository;
        public MasterpageController(IMasterpageRepository masterpageRepository)
        {
            _masterpageRepository = masterpageRepository;
        }
        [HttpGet("ModuleData")]
        public async Task<IActionResult> OnGetModule()
        {
            try
            {
                List<Modules> listOfModule = await _masterpageRepository.GetModule();
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
                List<Interfaces> listOfInterface = await _masterpageRepository.GetInterface();
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
