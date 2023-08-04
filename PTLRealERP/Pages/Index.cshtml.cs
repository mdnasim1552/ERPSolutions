using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealERPLIB.DapperRepository;
using System.Data;

namespace PTLRealERP.Pages
{
    //[Authorize(Policy = "MustBelongToHRDepartment")]
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDapperService _dapperService;

        public IndexModel(ILogger<IndexModel> logger, IDapperService dapperService)
        {
            _logger = logger;
            _dapperService = dapperService;
        }
        

        public void OnGet()
        {
            this.GETCOMMODULE_INTERFACE();         
        }

        private void GETCOMMODULE_INTERFACE()
        {            
            string comcod = "3101";
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "GETCOMMODULE_INTERFACE";
            string userid = "3101001";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Comp1", comcod);
            parameters.Add("@Calltype", Calltype);
            parameters.Add("@Desc1", userid);
            List<List<dynamic>> listOfModule = _dapperService.GetDataList(procedureName, parameters);
            ViewData["ModuleNames"] = listOfModule[0];
            ViewData["InterfaceNames"] = listOfModule[1];
        }

        //private void GetInterfacename()
        //{
        //    string comcod = "3101";
        //    string procedureName = "SP_UTILITY_LOGIN_MGT";
        //    string Calltype = "GETINTERFACE";
        //    string userid = "3101001";
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("@Comp1", comcod);
        //    parameters.Add("@Calltype", Calltype);
        //    parameters.Add("@Desc1", userid);
        //    List<List<dynamic>> listOfModule = _dapperService.GetDataList(procedureName, parameters);
        //    ViewData["InterfaceNames"] = listOfModule[0];
        //}
    }
}