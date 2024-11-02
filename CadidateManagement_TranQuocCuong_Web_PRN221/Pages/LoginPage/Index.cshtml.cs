using Candidate_BusinessObjects;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CadidateManagement_TranQuocCuong_Web_PRN221.Pages.LoginPage
{
    public class IndexModel : PageModel
    {
        private readonly IHRAccountService _hrAccountService;
        public IndexModel(IHRAccountService hrAccountService)
        {
            _hrAccountService = hrAccountService;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string email = Request.Form["txtEmail"];
            string password = Request.Form["txtPassword"];

            Hraccount account = _hrAccountService.GetHraccountByEmail(email);
            if (account != null && account.Password.Equals(password))
            {
                string RoleID = account.MemberRole.ToString();
                HttpContext.Session.SetString("RoleID", RoleID);
                if (RoleID == "3")
                {
                    Response.Redirect("/Permission");
                }
                else
                {
                    Response.Redirect("/CandidateProfilePage");
                }
            }
            else
                Response.Redirect("/Error");
        }
    }
}
