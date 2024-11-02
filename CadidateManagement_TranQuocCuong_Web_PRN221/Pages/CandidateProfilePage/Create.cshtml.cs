using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candidate_BusinessObjects;
using Candidate_DAO;
using Candidate_Service;
using Microsoft.AspNetCore.SignalR;
using CadidateManagement_TranQuocCuong_Web_PRN221.Hubs;

namespace CadidateManagement_TranQuocCuong_Web_PRN221.Pages.CandidateProfilePage
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;
        private readonly IJobPostingService jobPostingService;

        public CreateModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
        {
            this.candidateProfileService = candidateProfileService;
            this.jobPostingService = jobPostingService;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(jobPostingService.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || candidateProfileService.GetCandidateProfiles() == null || CandidateProfile == null)
            {
                return Page();
            }

            candidateProfileService.AddCandidateProfile(CandidateProfile);
            return RedirectToPage("./Index");
        }
    }
}
