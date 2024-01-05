using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEntity.Account;
using RealERPLIB.DapperRepository;
using System.Data;
using System.Data.Common;
using static RealERPLIB.DapperRepository.DapperService;

namespace PTLRealERP.Pages.Controller
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDapperService _dapperService;
        private readonly IDbConnection _dbConnection;
        public UsersController(IDapperService dapperService,IDbConnection dbConnection) {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
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
        [HttpPost("insertData")]
        public IActionResult InsertUserData(Userinf user)
        {
            try
            {
                // Here, 'updatedData' contains the data sent from the client in JSON format.
                // You can iterate through the 'updatedData' list and update your database accordingly.
                //Update userinf set usrsname=@Desc3,usrname=@Desc4,usrdesig=@Desc5,usractive=@Desc6,usrpass=@Desc7,mailid=@Desc8,userrole=@Desc9 where comcod=@Desc1 and usrid=@Desc2
                string procedureName = "SP_UTILITY_LOGIN_MGT";
                string Calltype = "INSERTUSER";

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
                parameters.Add("@Desc9", user.empid);
                _dbConnection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);

                // Return a success response
                return Ok("Data Inserted successfully");
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return BadRequest("An error occurred while updating data.");
            }
        }
        [HttpPost("updateData")]
        public IActionResult UpdateUserData([FromBody] List<Userinf> updatedData)
        {
            try
            {
                // Here, 'updatedData' contains the data sent from the client in JSON format.
                // You can iterate through the 'updatedData' list and update your database accordingly.
                //Update userinf set usrsname=@Desc3,usrname=@Desc4,usrdesig=@Desc5,usractive=@Desc6,usrpass=@Desc7,mailid=@Desc8,userrole=@Desc9 where comcod=@Desc1 and usrid=@Desc2
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
                    _dbConnection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
                }

                // Return a success response
                return Ok("Data updated successfully");
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return BadRequest("An error occurred while updating data.");
            }
        }

        [HttpPost("deleteData")]
        public IActionResult DeleteUserData([FromBody] Userinf user)
        {
            try
            {
                string procedureName = "SP_UTILITY_LOGIN_MGT";
                string Calltype = "DELETEUSER";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Calltype", Calltype);
                parameters.Add("@Comp1", user.comcod);
                parameters.Add("@Desc1", user.usrid);
                _dbConnection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return Ok("Data deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while updating data.");
            }
        }

    }
}
