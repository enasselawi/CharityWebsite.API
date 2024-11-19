using CharityWebsite.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CharityWebsite.Core.Data.Charity;

namespace CharityWebsite.Core.Repository
{
    public interface ICharityRepository
    {
        List<Charity> GetAllCharities();
        Charity GetCharityById(int id);
        void CreateCharity(Charity charity);
        void UpdateCharity(Charity charity);
        void DeleteCharity(int id);

        // the new method 
        List<Charity> GetCharitiesByUserId(int userId);
        // Add these methods for About Us and Home Content
        Aboutuscontent GetAboutUsContent();
        Homecontent GetHomeContent();
        void UpdateAboutUsContent(Aboutuscontent content);
        void UpdateHomeContent(Homecontent content);
    }
}
