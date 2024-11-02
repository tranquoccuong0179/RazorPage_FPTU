using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext context;
        private static CandidateProfileDAO instance;

        public CandidateProfileDAO()
        {
            context = new CandidateManagementContext();
        }

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return context.CandidateProfiles.Include(cp => cp.Posting).ToList();
        }

        public List<CandidateProfile> GetCandidateByName(string fullName) 
        {
            var entity = context.CandidateProfiles.Where(x => x.Fullname.ToLower().Contains(fullName.ToLower())).Include(cp => cp.Posting).ToList();
            return entity;
        }
        public CandidateProfile GetCandidate(string id)
        {

            var entity = context.CandidateProfiles.Include(x => x.Posting).SingleOrDefault(m => m.CandidateId.Equals(id));
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfileNew)
        {
            bool result = false;
            CandidateProfile candidateProfile = GetCandidate(candidateProfileNew.CandidateId);
            try
            {
                if (candidateProfile == null)
                {
                    context.CandidateProfiles.Add(candidateProfileNew);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = GetCandidate(candidateProfile.CandidateId);
            try
            {
                if (candidate != null)
                {
                    context.Entry<CandidateProfile>(candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    result = true;
                }
            } 
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = GetCandidate(candidateProfile.CandidateId);
            try
            {
                if (candidate != null)
                {
                    context.CandidateProfiles.Remove(candidateProfile);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
    }
}
