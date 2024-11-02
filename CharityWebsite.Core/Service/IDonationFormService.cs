﻿using CharityWebsite.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Service
{
    public interface IDonationFormService
    {
        List<Donationform> GetAllDonationForms();
        Donationform GetDonationFormById(int id);
        void CreateDonationForm(Donationform donationForm);
        void UpdateDonationForm(Donationform donationForm);
        void DeleteDonationFormById(int id);
    }
}
