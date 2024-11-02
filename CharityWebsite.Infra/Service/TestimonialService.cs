using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using CharityWebsite.Core.Service;
using CharityWebsite.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {

        private readonly ITestimonialRepository testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            this.testimonialRepository = testimonialRepository;
        }
        public List<Testimonial> GetAllTestimonials()
        {
            return testimonialRepository.GetAllTestimonials();
        }

        public Testimonial GetTestimonialById(int id)
        {
            return testimonialRepository.GetTestimonialById(id);
        }

        public void CreateTestimonial(Testimonial testimonial)
        {
            testimonialRepository.CreateTestimonial(testimonial);
        }

        public void UpdateTestimonial(Testimonial testimonial)
        {
            testimonialRepository.UpdateTestimonial(testimonial);
        }

        public void DeleteTestimonial(int id)
        {
            testimonialRepository.DeleteTestimonial(id);
        }


    }
}
