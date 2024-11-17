using CharityWebsite.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Repository
{
    public interface ICharityCategoryRepository
    {
        List<Charitycategory> GetAllCharityCategories();
        Charitycategory GetCharityCategoryById(int id);
        void CreateCharityCategory(Charitycategory charityCategory);
        void UpdateCharityCategory(Charitycategory charityCategory);
        void DeleteCharityCategory(int id);
        //the new added get charity category with charities related to 
        List<CharityCategoryWithCharities> GetAllCharityCategoriesWithCharities();
        // the new 
        List<CharityCategoryWithPaidCharities> GetCategoriesAndPaidCharities();
       

    }
}
