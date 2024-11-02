using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CadidateManagement_TranQuocCuong_Web_PRN221.Pages
{
    public class PermissionModel : PageModel
    {
        public IActionResult OnGet()
        {
            var roleID = HttpContext.Session.GetString("RoleID");
            if (roleID != "3")
            {
                return RedirectToPage("/LoginPage/Index");
            }

            return Page();
        }

    }
}
