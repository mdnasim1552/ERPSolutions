using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using RealEntity.Account;
using RealERPLIB.DapperRepository;
using RealERPLIB.Extensions;
using RealERPLIB.LoginRepository;
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
        public Credential Credential { get; set; } = new Credential();
        [BindProperty]
        public string SelectedCompanyId { get; set; }
        public List<Company> CompanyList { get; set; }  = new List<Company>();
        public DataTable MyDataTable { get; set; }= new DataTable();
        public List<List<dynamic>> result { get; set; } = new List<List<dynamic>>();

        private readonly IDapperService _dapperService;
        private readonly ILoginRepository _loginRepository;
        public LoginModel(IDapperService dapperService,ILoginRepository loginRepository)
        {
            _dapperService = dapperService;
            _loginRepository = loginRepository;
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
       
        private async Task GetCompanyInfoAsync()
        {
            CompanyList = await _loginRepository.GetCompanyList();       
            //result = _dapperService.GetDataList(procedureName, parameters);
            //List<Company> companyList = result[0].ConvertToCustomList<Company>();
        }
        public async Task OnGet()
        {
            await this.GetCompanyInfoAsync();
            //this.GetModulename();

            //ViewBag.ModuleNames = result[0];
            // or
            //ViewData["ModuleNames"] = result[0];
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
            //string procedureName = "SP_UTILITY_LOGIN_MGT";
            //string Calltype = "LOGINUSER";
            string username = Credential.Username;
            string password = ASTUtility.EncodePassword(Credential.Password);//ASTUtility.EncodePassword(this.txtuserpass.Text.Trim());
            string comcod = SelectedCompanyId;
            //DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("@Calltype", Calltype);
            //parameters.Add("@Comp1", comcod);
            //parameters.Add("@Desc1", username);
            //parameters.Add("@Desc2", password);
            //var LoginUsers = await _dapperService.GetFirstOrDefaultAsync<LoginUsers>(procedureName, parameters);
            var LoginUsers=await _loginRepository.GetLoginUsers(comcod, username, password); 
            if (LoginUsers != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,LoginUsers.usrname),
                    new Claim(ClaimTypes.Email,LoginUsers.mailid),
                    new Claim("Image", $"/Images/Comp_Logo/{comcod}.jpg"), // Set the actual path to the image$"{comcod}.jpg"
                    new Claim("Designation", LoginUsers.usrdesig), // Set the actual designation
                    new Claim("comcod", comcod),
                    new Claim(ClaimTypes.Role,LoginUsers.userrole)
                    //new Claim("Department","HR"),
                    //new Claim("Admin","true")
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);//we can use CookieAuthenticationDefaults.AuthenticationScheme (constant) instead of "MyCookieAuth"
                ClaimsPrincipal claimprincipal = new ClaimsPrincipal(identity);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = Credential.IsRemember
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimprincipal, authProperties);
                return RedirectToPage("/Index");
            }
            else {
                await this.GetCompanyInfoAsync();
                return Page();
            }
            
        }
    }
   
   
}
