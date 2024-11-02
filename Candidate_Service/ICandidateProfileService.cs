using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public interface ICandidateProfileService
    {
        public List<CandidateProfile> GetCandidateProfiles();
        (List<CandidateProfile> Items, int TotalItems, int TotalPages) GetCandidateProfiles(int pageNumber, int pageSizem, string searchName = null);
        public CandidateProfile GetCandidateProfileById(string id);
        public bool AddCandidateProfile(CandidateProfile candidateProfile);
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile);
    }
}
