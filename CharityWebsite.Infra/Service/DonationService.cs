using CharityWebsite.Core.Repository;
using CharityWebsite.Core.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Infra.Service
{
    public class DonationService: IDonationService
    {
        private readonly IDonationRepository _donationRepository;

        public DonationService(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public void ProcessDonation(int userID, int charityID, decimal amount, string cardNumber, DateTime expiryDate, string cvv)
        {
            _donationRepository.ProcessDonation(userID, charityID, amount, cardNumber, expiryDate, cvv);
        }


    }
}
