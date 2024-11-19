using CharityWebsite.Core.Common;
using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using Dapper;

using System.Data;
using static CharityWebsite.Core.Data.Charity;


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




        public Aboutuscontent GetAboutUsContent()
        {
            var p = new DynamicParameters();

            // Increase the buffer size for p_title and use DbType.String for CLOB data
            p.Add("p_title", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000); // Increased size
            p.Add("p_content", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000); // Use large size for CLOB

            // Execute the stored procedure
            dBContext.Connection.Execute("CONTENT_PACKAGE.GET_ABOUT_US_CONTENT", p, commandType: CommandType.StoredProcedure);

            return new Aboutuscontent
            {
                Title = p.Get<string>("p_title"),
                Content = p.Get<string>("p_content")
            };
        }



        public Homecontent GetHomeContent()
        {
            var p = new DynamicParameters();

            // Use sufficient buffer sizes and specify DbType.String for CLOB data
            p.Add("p_title", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
            p.Add("p_content", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);

            // Execute the stored procedure
            dBContext.Connection.Execute("CONTENT_PACKAGE.GET_HOME_CONTENT", p, commandType: CommandType.StoredProcedure);

            // Return the result as a Homecontent object
            return new Homecontent
            {
                Title = p.Get<string>("p_title"),
                Content = p.Get<string>("p_content")
            };
        }


        // Method to update About Us content
        public void UpdateAboutUsContent(Aboutuscontent content)
        {
            var p = new DynamicParameters();
            p.Add("p_title", content.Title, DbType.String, ParameterDirection.Input);
            p.Add("p_content", content.Content, DbType.String, ParameterDirection.Input);

            dBContext.Connection.Execute("CONTENT_PACKAGE.UPDATE_ABOUT_US_CONTENT", p, commandType: CommandType.StoredProcedure);
        }

        // Method to update Home content
        public void UpdateHomeContent(Homecontent content)
        {
            var p = new DynamicParameters();
            p.Add("p_title", content.Title, DbType.String, ParameterDirection.Input);
            p.Add("p_content", content.Content, DbType.String, ParameterDirection.Input);

            dBContext.Connection.Execute("CONTENT_PACKAGE.UPDATE_HOME_CONTENT", p, commandType: CommandType.StoredProcedure);
        }
















    }
}
