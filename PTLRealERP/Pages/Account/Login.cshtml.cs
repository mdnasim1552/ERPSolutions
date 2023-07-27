using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using RealERPLIB.DapperRepository;
using RealERPLIB.Extensions;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Claims;
using static RealERPLIB.DapperRepository.DapperService;

namespace PTLRealERP.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        private readonly IDbConnection _dbConnection;
        public DataTable MyDataTable { get; set; }
        public List<List<dynamic>> result { get; set; }

        //public LoginModel(IDbConnection dbConnection)
        //{
        //    _dbConnection = dbConnection;
        //}
        private readonly IDapperService _dapperService;

        public LoginModel(IDapperService dapperService, IDbConnection dbConnection)
        {
            _dapperService = dapperService;
            _dbConnection= dbConnection;
        }

        //private void GetModulename()
        //{


        //    Hashtable hst = (Hashtable)Session["tblLogin"];
        //    string comcod = this.GetCompCode();
        //    ProcessAccess ulogin = new ProcessAccess();
        //    string usrid = hst["usrid"].ToString();
        //    // string usrperm = "1";
        //    DataSet ds1 = ulogin.GetTransInfo(comcod, "SP_UTILITY_LOGIN_MGT", "GETCOMMODULE", usrid, "", "", "", "", "", "", "", "");

        //    DataView dv = ds1.Tables[0].DefaultView;
        //    dv.RowFilter = ("moduleid<>'AA' AND usrper='True'");

        //    this.ddlModuleName.DataTextField = "modulename";
        //    this.ddlModuleName.DataValueField = "moduleid";
        //    this.ddlModuleName.DataSource = dv.ToTable();
        //    this.ddlModuleName.DataBind();


        //    ViewState["tblmoduleName"] = ds1.Tables[0];

        //}
        private void GetModulename()
        {
            string comcod = "3101";
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "GETCOMMODULE";
            string userid = "3101001";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Comp1", comcod);
            parameters.Add("@Calltype", Calltype);
            parameters.Add("@Desc1", userid);
            result = _dapperService.GetDataList(procedureName, parameters);
        }
        public void OnGet()
        {
            this.GetModulename();

            //ViewBag.ModuleNames = result[0];
            // or
            ViewData["ModuleNames"] = result[0];
            //var comcod = "3101";
            //var Calltype = "LOGIN";
            ////List<User> users = _dapperService.GetAll();
            //string procedureName = "SP_UTILITY_LOGIN_MGT";
            //DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("@Comp1", comcod);
            //parameters.Add("@Calltype", Calltype);
            //// Add any parameters if required, e.g., parameters.Add("paramName", paramValue);
            //List<List<dynamic>> result=_dapperService.GetDataList(procedureName, parameters);

            //var parameters2 = new[]
            //{
            //    new SqlParameter("@Comp1", SqlDbType.VarChar) { Value = "3101" },
            //    new SqlParameter("@Calltype", SqlDbType.VarChar) { Value = "LOGIN" }
            //};

            ////foreach (var result in firstResultSet)
            ////{
            ////    var nameValue = result.COMNAM; // Access the 'Name' property dynamically
            ////                                 // Do something with the 'nameValue'
            ////}

            //var sql = "select * from compinf";
            //var user= _dbConnection.Query<User>(sql).ToList();
            //List<DataTable> result2 = _dapperService.GetDataTableList(procedureName, parameters);
            ////MyDataTable = result[0];


            //var tupleResult = _dapperService.GetUserAndCustomerLists(procedureName, parameters);

            //// Extract the lists from the tuple
            //List<User> users = tupleResult.users;
            //List<Module> modul = tupleResult.mod;

            //// Process the lists as needed
            //foreach (User usr in users)
            //{
            //    // Access User properties
            //    Console.WriteLine($"User - UserId: {usr.comcod}, UserName: {usr.comnam}");
            //    // Access other User-specific properties here
            //}

            //foreach (var m in modul)
            //{
            //    // Access Customer properties
            //    Console.WriteLine($"Customer - CustomerId: {m.moduleid}, CustomerName: {m.modulename}");
            //    // Access other Customer-specific properties here
            //}

            //DataTable dt = result2[1];
            ////DataTable dt = new DataTable();
            //List<Module> Mlist = dt.DataTableToList<Module>();

            //DataTable dt2 = Mlist.ListToDataTable<Module>();  

        }
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) return Page();
            if(Credential.Username=="admin" && Credential.Password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"admin"),
                    new Claim(ClaimTypes.Email,"admin@mywebside.com"),
                    new Claim("Department","HR"),
                    new Claim("Admin","true")
                };
                ClaimsIdentity identity=new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);//we can use CookieAuthenticationDefaults.AuthenticationScheme (constant) instead of "MyCookieAuth"
                ClaimsPrincipal claimprincipal=new ClaimsPrincipal(identity);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent=Credential.IsRemember
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimprincipal, authProperties);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
    public class Credential
    {
        
        [Required]
        [Display(Name ="User Name")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool IsRemember { get; set; }
        public string Company { get; set; }
    }
}
