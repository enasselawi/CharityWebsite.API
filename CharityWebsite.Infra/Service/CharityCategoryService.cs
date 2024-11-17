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
    public class CharityCategoryService : ICharityCategoryService
    {
        private readonly ICharityCategoryRepository _repository;

        public CharityCategoryService(ICharityCategoryRepository repository)
        {
            _repository = repository;
        }

        public List<Charitycategory> GetAllCharityCategories() => _repository.GetAllCharityCategories();

        public Charitycategory GetCharityCategoryById(int id) => _repository.GetCharityCategoryById(id);

        public void CreateCharityCategory(Charitycategory charityCategory) => _repository.CreateCharityCategory(charityCategory);

        public void UpdateCharityCategory(Charitycategory charityCategory) => _repository.UpdateCharityCategory(charityCategory);

        public void DeleteCharityCategory(int id) => _repository.DeleteCharityCategory(id);
        // the new added 
        public List<CharityCategoryWithCharities> GetAllCharityCategoriesWithCharities()
        {
            return _repository.GetAllCharityCategoriesWithCharities();
        }
        //the new 
        public List<CharityCategoryWithPaidCharities> GetCategoriesAndPaidCharities()
        {
            return _repository.GetCategoriesAndPaidCharities();
        }


    }
}
