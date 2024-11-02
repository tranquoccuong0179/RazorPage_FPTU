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
using Candidate_Service;

namespace CadidateManagement_TranQuocCuong_Web_PRN221.Pages.CandidateProfilePage
{
    public class EditModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;
        private readonly IJobPostingService jobPostingService;

        public EditModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
        {
            this.candidateProfileService = candidateProfileService;
            this.jobPostingService = jobPostingService;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || candidateProfileService.GetCandidateProfiles() == null)
            {
                return NotFound();
            }

            var candidateprofile = candidateProfileService.GetCandidateProfileById(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
            ViewData["PostingId"] = new SelectList(jobPostingService.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool updateSuccess = candidateProfileService.UpdateCandidateProfile(CandidateProfile);

            if (!updateSuccess)
            {
                if (!CandidateProfileExists(CandidateProfile.CandidateId))
                {
                    return NotFound();
                }
                else
                {
                    throw new DbUpdateConcurrencyException();
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CandidateProfileExists(string id)
        {
            return candidateProfileService.GetCandidateProfileById(id) != null;
        }
    }
}
