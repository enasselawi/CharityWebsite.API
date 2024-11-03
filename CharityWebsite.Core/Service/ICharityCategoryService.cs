using CharityWebsite.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Service
{
    public interface ICharityCategoryService
    {
        List<Charitycategory> GetAllCharityCategories();
        Charitycategory GetCharityCategoryById(int id);
        void CreateCharityCategory(Charitycategory charityCategory);
        void UpdateCharityCategory(Charitycategory charityCategory);
        void DeleteCharityCategory(int id);
    }
}
