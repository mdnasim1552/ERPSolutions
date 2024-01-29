using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PTLRealERP.Pages.F_21_GAcc
{
    [Authorize]
    public class AccSubCodeBookModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost() { 
        }
    }
}
