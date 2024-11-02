using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public interface IJobPostingService
    {
        public List<JobPosting> GetJobPostings();
        public JobPosting GetJobPosting(string jobId);
        public bool AddJobPosting(JobPosting jobPosting);
        public bool UpdateJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(JobPosting jobPosting);
    }
}
