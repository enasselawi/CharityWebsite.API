using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Service
{
    public interface IDonationService
    {
        void Donate(int userID, int charityID, decimal amount, string cardNumber, DateTime expiryDate, string cvv);

    }
}
