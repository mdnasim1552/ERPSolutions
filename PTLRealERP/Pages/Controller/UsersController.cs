using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEntity.Account;
using RealERPLIB.DapperRepository;

namespace PTLRealERP.Pages.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDapperService _dapperService;
        public UsersController(IDapperService dapperService) {
            _dapperService = dapperService;
        }


        [HttpGet("myData")]
        public IActionResult OnGetUserList()
        {
            try
            {
                string procedureName = "SP_UTILITY_LOGIN_MGT";
                string Calltype = "SHOWUSER";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Calltype", Calltype);
                var userList = _dapperService.GetList<Userinf>(procedureName, parameters);               
                // Serialize the structured data to JSON and return as response
                var json = JsonConvert.SerializeObject(new { data = userList });
                return Ok(json);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return BadRequest("An error occurred while fetching data.");
            }
        }

        //[HttpGet("myData")]
        //public IActionResult OnGetUserList()
        //{
        //    string procedureName = "SP_UTILITY_LOGIN_MGT";
        //    string Calltype = "SHOWUSER";
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("@Calltype", Calltype);

        //    var userList = _dapperService.GetList<Userinf>(procedureName, parameters);

        //    // Transform the array of objects into an array of arrays
        //    var transformedData = userList.Select(user => new object[]
        //    {
        //        user.comcod,
        //        user.usrid,
        //        user.usrsname,
        //        user.usrname,
        //        user.usrdesig,
        //        user.usractive,
        //        user.usrpass,
        //        user.mailid,
        //        user.empid,
        //        user.userrole
        //    }).ToList();

        //    return Ok(new { data = transformedData });
        //}

    }
}
