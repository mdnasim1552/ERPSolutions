using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PTLRealERP.Pages.Accounts;
using RealEntity.Account;
using RealERPLIB.ControllersRepository;
using RealERPLIB.DapperRepository;
using RealERPLIB.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using static RealERPLIB.DapperRepository.DapperService;

namespace PTLRealERP.Pages.Controller
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }


        [HttpGet("myData")]
        public async Task<IActionResult> GetUserList()
        {
            try
            {
                var userList = await _userRepository.GetUserList();
                var json = JsonConvert.SerializeObject(new { data = userList });
                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while fetching data.");
            }
        }
        [HttpPost("insertData")]
        public async Task<IActionResult> InsertUserData(Userinf user)
        {
            try
            {
                bool result = await _userRepository.InsertUserData(user);
                if (!result)
                {
                    return BadRequest(new { Status = "Error", Message = "An error occurred while updating data." });
                }           
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while updating data.");
            }
            return Ok("Data Inserted successfully");
        }
        [HttpPost("updateData")]
        public async Task<IActionResult> UpdateUserData([FromBody] List<Userinf> updatedData)
        {
            try
            {
                bool result = await _userRepository.UpdateUserData(updatedData);
                if (!result)
                {
                    return BadRequest(new { Status = "Error", Message = "An error occurred while updating data." });
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

        [HttpPost]
        [Route("/api/Users/deleteData")]
        public async Task<IActionResult> DeleteUserData([FromBody] DeleteRequestModel request)
        {
            try
            {

                string comcod = request.Comcod;
                string usrid = request.Usrid;
                bool result= await _userRepository.DeleteUserData(comcod,usrid);  
                if (!result)
                {
                    return BadRequest(new { Status = "Error", Message = "An error occurred while updating data." });
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while updating data.");
            }
            return Ok("Data deleted successfully");
        }
        public class DeleteRequestModel
        {
            [Required(ErrorMessage = "comcod is required")]
            public string Comcod { get; set; }

            [Required(ErrorMessage = "usrid is required")]
            public string Usrid { get; set; }
        }

    }
}
