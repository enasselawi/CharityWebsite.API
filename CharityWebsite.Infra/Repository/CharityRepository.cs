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
    public class CharityRepository : ICharityRepository
    {
        private readonly IDbContext dBContext;
        public CharityRepository(IDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public List<Charity> GetAllCharities()
        {
            IEnumerable<Charity> result = dBContext.Connection.Query<Charity>("CHARITY_PACKAGE.GET_ALL_CHARITIES", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Charity GetCharityById(int id)
        {
            var p = new DynamicParameters();
            p.Add("new_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.Query<Charity>("CHARITY_PACKAGE.GET_CHARITY_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateCharity(Charity charity)
        {
            var p = new DynamicParameters();
            p.Add("new_name", charity.Charityname, DbType.String, ParameterDirection.Input);
            p.Add("new_description", charity.Charitydescription, DbType.String, ParameterDirection.Input);
            p.Add("new_location", charity.Location, DbType.String, ParameterDirection.Input);
            p.Add("new_goals", charity.Goals, DbType.String, ParameterDirection.Input);
          //  p.Add("new_status", charity.Status, DbType.String, ParameterDirection.Input);
            p.Add("new_status", charity.Status ?? "Pending", DbType.String, ParameterDirection.Input); // Default to "Pending"
            p.Add("new_user_id", charity.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("new_category_id", charity.Charitycategoryid, DbType.Int32, ParameterDirection.Input);
            p.Add("new_mission", charity.Mission, DbType.String, ParameterDirection.Input);
            dBContext.Connection.Execute("CHARITY_PACKAGE.CREATE_CHARITY", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCharity(Charity charity)
        {
            var p = new DynamicParameters();
            p.Add("new_id", charity.Charityid, DbType.Int32, ParameterDirection.Input);
            p.Add("new_name", charity.Charityname, DbType.String, ParameterDirection.Input);
            p.Add("new_description", charity.Charitydescription, DbType.String, ParameterDirection.Input);
            p.Add("new_location", charity.Location, DbType.String, ParameterDirection.Input);
            p.Add("new_goals", charity.Goals, DbType.String, ParameterDirection.Input);
            p.Add("new_status", charity.Status, DbType.String, ParameterDirection.Input);
            p.Add("new_user_id", charity.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("new_category_id", charity.Charitycategoryid, DbType.Int32, ParameterDirection.Input);
            p.Add("new_mission", charity.Mission, DbType.String, ParameterDirection.Input);
            dBContext.Connection.Execute("CHARITY_PACKAGE.UPDATE_CHARITY", p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteCharity(int id)
        {
            var p = new DynamicParameters();
            p.Add("new_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dBContext.Connection.Execute("CHARITY_PACKAGE.DELETE_CHARITY", p, commandType: CommandType.StoredProcedure);
        }


        public List<Charity> GetCharitiesByUserId(int userId)
        {
            var p = new DynamicParameters();
            p.Add("new_user_id", userId, DbType.Int32);
            return dBContext.Connection.Query<Charity>("USER_CHARITY_PACKAGE.GET_CHARITIES_BY_USER_ID", p, commandType: CommandType.StoredProcedure).ToList();
        }

















    }
}
