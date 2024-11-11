using CharityWebsite.Core.Common;
using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Infra.Repository
{
    public class CharityCategoryRepository : ICharityCategoryRepository
    {
        private readonly IDbContext _dbContext;

        public CharityCategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Charitycategory> GetAllCharityCategories()
        {
            var result = _dbContext.Connection.Query<Charitycategory>("CHARITYCATEGORY_PACKAGE.GETALLCHARITYCATEGORIES", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Charitycategory GetCharityCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Int32, ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Charitycategory>("CHARITYCATEGORY_PACKAGE.GETCHARITYCATEGORYBYID", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateCharityCategory(Charitycategory charityCategory)
        {
            var p = new DynamicParameters();
            p.Add("NEW_CATEGORYNAME", charityCategory.Categoryname, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute("CHARITYCATEGORY_PACKAGE.CREATECHARITYCATEGORY", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCharityCategory(Charitycategory charityCategory)
        {
            var p = new DynamicParameters();
            p.Add("ID", charityCategory.Charitycategoryid, DbType.Int32, ParameterDirection.Input);
            p.Add("NEW_CATEGORYNAME", charityCategory.Categoryname, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute("CHARITYCATEGORY_PACKAGE.UPDATECHARITYCATEGORY", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCharityCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("CHARITYCATEGORY_PACKAGE.DELETECHARITYCATEGORY", p, commandType: CommandType.StoredProcedure);
        }
        public List<CharityCategoryWithCharities> GetAllCharityCategoriesWithCharities()
        {
            var result = _dbContext.Connection.Query<CharityCategoryWithCharities>(
                "CHARITYCATEGORY_PACKAGE.GET_ALL_CATEGORIES_WITH_CHARITIES",
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }

    }
}
