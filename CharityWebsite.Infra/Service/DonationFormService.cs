using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using CharityWebsite.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Infra.Service
{
    public class DonationFormService: IDonationFormService
    {
        private readonly IDonationFormRepository _donationFormRepository;

        public DonationFormService(IDonationFormRepository donationFormRepository)
        {
            _donationFormRepository = donationFormRepository;
        }

        public List<Donationform> GetAllDonationForms()
        {
            return _donationFormRepository.GetAllDonationForms();
        }

        public Donationform GetDonationFormById(int id)
        {
            return _donationFormRepository.GetDonationFormById(id);
        }

        public void CreateDonationForm(Donationform donationForm)
        {
            _donationFormRepository.CreateDonationForm(donationForm);
        }

        public void UpdateDonationForm(Donationform donationForm)
        {
            _donationFormRepository.UpdateDonationForm(donationForm);
        }

        public void DeleteDonationFormById(int id)
        {
            _donationFormRepository.DeleteDonationFormById(id);
        }
    }
}
