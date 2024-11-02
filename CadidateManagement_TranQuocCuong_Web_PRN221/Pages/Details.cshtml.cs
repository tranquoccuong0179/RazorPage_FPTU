using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candidate_BusinessObjects;
using Candidate_DAO;

namespace CadidateManagement_TranQuocCuong_Web_PRN221.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Candidate_DAO.CandidateManagementContext _context;

        public DetailsModel(Candidate_DAO.CandidateManagementContext context)
        {
            _context = context;
        }

      public Hraccount Hraccount { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Hraccounts == null)
            {
                return NotFound();
            }

            var hraccount = await _context.Hraccounts.FirstOrDefaultAsync(m => m.Email == id);
            if (hraccount == null)
            {
                return NotFound();
            }
            else 
            {
                Hraccount = hraccount;
            }
            return Page();
        }
    }
}
