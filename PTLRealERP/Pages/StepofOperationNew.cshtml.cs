using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEntity.ConstantInfo;
using RealERPLIB.ConstantInfo;

namespace PTLRealERP.Pages
{
    public class StepofOperationNewModel : PageModel
    {
        public string Type { get; private set; }
        public List<MenuItems> menuItems { get; set; } = new List<MenuItems>();
        public async Task OnGet()
        {
            Type = HttpContext.Request.Query["Type"];
            if (Type == "81")
            {
                menuItems =await ConstantInfo.MenuAllHR();
            }
            
        }
    }
}
