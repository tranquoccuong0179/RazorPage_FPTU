using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candidate_BusinessObjects;
using Candidate_DAO;

namespace CadidateManagement_TranQuocCuong_Web_PRN221.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Candidate_DAO.CandidateManagementContext _context;

        public CreateModel(Candidate_DAO.CandidateManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hraccount Hraccount { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Hraccounts == null || Hraccount == null)
            {
                return Page();
            }

            _context.Hraccounts.Add(Hraccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
