﻿using CharityWebsite.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Repository
{
    public interface ITestimonialRepository
    {
        List<Testimonial> GetAllTestimonials();
        Testimonial GetTestimonialById(int id);
        void CreateTestimonial(Testimonial testimonial);
        void UpdateTestimonial(Testimonial testimonial);
        void DeleteTestimonial(int id);
    }
}
