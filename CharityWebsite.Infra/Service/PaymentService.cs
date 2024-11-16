using CharityWebsite.Core.Repository;
using CharityWebsite.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Infra.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }
        public void PayForPost(int userId, int charityId, decimal amount, long cardNumber, DateTime expiryDate, int cvv)
        {
            _repository.PayForPost(userId, charityId, amount, cardNumber, expiryDate, cvv);
        }
    }
}
