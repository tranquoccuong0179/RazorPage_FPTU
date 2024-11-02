using Candidate_BusinessObjects;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class HRAccountService : IHRAccountService
    {
        private readonly IHRAccountRepository iAccountRepo;

        //Dùng Razor
        public HRAccountService(IHRAccountRepository iAccountRepo) 
        { 
            this.iAccountRepo = iAccountRepo;
        }

        //Dùng cho WPF

        public HRAccountService()
        {
            this.iAccountRepo = new HRAccountRepository();
        }
        public Hraccount GetHraccountByEmail(string email)
        {
            return iAccountRepo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccounts()
        {
            return iAccountRepo.GetHraccounts();
        }
    }
}
