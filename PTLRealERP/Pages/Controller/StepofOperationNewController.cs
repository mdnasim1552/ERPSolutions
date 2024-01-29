using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealERPLIB.DapperRepository;
using System.Data;

namespace PTLRealERP.Pages.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StepofOperationNewController : ControllerBase
    {
        private readonly IDapperService _dapperService;
        private readonly IDbConnection _dbConnection;
        public StepofOperationNewController(IDapperService dapperService, IDbConnection dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection = dbConnection;
        }
    }
}
