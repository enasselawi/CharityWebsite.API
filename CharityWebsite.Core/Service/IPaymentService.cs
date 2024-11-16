using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Service
{
    public interface IPaymentService
    {
        void PayForPost(int userId, int charityId, decimal amount, long cardNumber, DateTime expiryDate, int cvv);

    }
}
