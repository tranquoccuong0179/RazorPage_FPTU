using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Candidate_BusinessObjects;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc;

namespace CadidateManagement_TranQuocCuong_Web_PRN221.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;

        public IndexModel(ICandidateProfileService context)
        {
            candidateProfileService = context;
        }

        public IList<CandidateProfile> CandidateProfiles { get; set; } = default!;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 4, string searchName = null)
        {
            SearchName = searchName ?? SearchName;
            var (items, totalItems, totalPages) = candidateProfileService.GetCandidateProfiles(pageNumber, pageSize, SearchName);

            CandidateProfiles = items;
            CurrentPage = pageNumber;
            TotalPages = totalPages;
        }
    }
}
