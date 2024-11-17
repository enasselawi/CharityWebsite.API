﻿using CharityWebsite.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Service
{
    public interface ICharityService
    {
        List<Charity> GetAllCharities();
        Charity GetCharityById(int id);
        void CreateCharity(Charity charity);
        void UpdateCharity(Charity charity);
        void DeleteCharity(int id);
     

    }
}
