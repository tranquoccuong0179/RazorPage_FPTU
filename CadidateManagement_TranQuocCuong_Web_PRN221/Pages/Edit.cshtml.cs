using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Candidate_BusinessObjects;
using Candidate_DAO;

namespace CadidateManagement_TranQuocCuong_Web_PRN221.Pages
{
    public class EditModel : PageModel
    {
        private readonly Candidate_DAO.CandidateManagementContext _context;

        public EditModel(Candidate_DAO.CandidateManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hraccount Hraccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Hraccounts == null)
            {
                return NotFound();
            }

            var hraccount =  await _context.Hraccounts.FirstOrDefaultAsync(m => m.Email == id);
            if (hraccount == null)
            {
                return NotFound();
            }
            Hraccount = hraccount;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Hraccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HraccountExists(Hraccount.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HraccountExists(string id)
        {
          return (_context.Hraccounts?.Any(e => e.Email == id)).GetValueOrDefault();
        }
    }
}
