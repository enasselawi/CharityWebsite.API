using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using CharityWebsite.Core.Service;
using CharityWebsite.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CharityWebsite.Core.Data.Charity;

namespace CharityWebsite.Infra.Service
{
    public class CharityService : ICharityService
    {
        private readonly ICharityRepository charityRepository;
        public CharityService(ICharityRepository charityRepository)
        {
            this.charityRepository = charityRepository;
        }
        public List<Charity> GetAllCharities()
        {
            return charityRepository.GetAllCharities();
        }

        public Charity GetCharityById(int id)
        {
            return charityRepository.GetCharityById(id);
        }

        public void CreateCharity(Charity charity)
        {
            charityRepository.CreateCharity(charity);
        }

        public void UpdateCharity(Charity charity)
        {
            charityRepository.UpdateCharity(charity);
        }

        public void DeleteCharity(int id)
        {
            charityRepository.DeleteCharity(id);
        }
        // New method to call GetCharitiesByUserId

        public List<Charity> GetCharitiesByUserId(int userId) => charityRepository.GetCharitiesByUserId(userId);



        public Aboutuscontent GetAboutUsContent() => charityRepository.GetAboutUsContent();

        public Homecontent GetHomeContent() => charityRepository.GetHomeContent();

        public void UpdateAboutUsContent(Aboutuscontent content) => charityRepository.UpdateAboutUsContent(content);

        public void UpdateHomeContent(Homecontent content) => charityRepository.UpdateHomeContent(content);


    }
}





