using CharityWebsite.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Repository
{
    public interface IDonationRepository
    {
        //void ProcessDonation(int userId, int charityId, decimal amount, long cardNumber, DateTime expiryDate, int cvv);


        void ProcessDonation(int userID, int charityID, decimal amount, string cardNumber, DateTime expiryDate, string cvv);
       

    }
}
