using Candidate_BusinessObjects;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private ICandidateProfileRepository iCandidateProfileRepo;
        public CandidateProfileService(ICandidateProfileRepository candidateProfileRepository)
        {
            iCandidateProfileRepo = candidateProfileRepository;
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return iCandidateProfileRepo.GetCandidateProfiles();
        }

        public (List<CandidateProfile> Items, int TotalItems, int TotalPages) GetCandidateProfiles(int pageNumber, int pageSize, string searchName = null)
        {
            List<CandidateProfile> allProfiles;

            if (!string.IsNullOrEmpty(searchName))
            {
                allProfiles = iCandidateProfileRepo.GetCandidateByName(searchName);
            }
            else
            {
                allProfiles = iCandidateProfileRepo.GetCandidateProfiles();
            }

            var totalItems = allProfiles.Count();

            var pagedProfiles = allProfiles
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return (pagedProfiles, totalItems, totalPages);
        }


        public CandidateProfile GetCandidateProfileById(string id)
        {
            return iCandidateProfileRepo.GetCandidateProfileById(id);
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return iCandidateProfileRepo.AddCandidateProfile(candidateProfile);
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            
            return iCandidateProfileRepo.UpdateCandidateProfile(candidateProfile);
        }

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            return iCandidateProfileRepo.DeleteCandidateProfile(candidateProfile);
        }

    }
}
