using CharityWebsite.Core.Common;
using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // View Profile Method
        public Userr GetUserProfile(int userID)
        {
            var p = new DynamicParameters();
            p.Add("p_userID", userID, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Fname", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            p.Add("p_Lname", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            p.Add("p_email", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            p.Add("p_password", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            p.Add("p_ImagePath", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

            // Execute the stored procedure
            _dbContext.Connection.Execute("VIEW_USER_PROFILE", p, commandType: CommandType.StoredProcedure);

            // Retrieve the output values
            var user = new Userr
            {
                Fname = p.Get<string>("p_Fname"),
                Lname = p.Get<string>("p_Lname"),
                Email = p.Get<string>("p_email"),
                Password = p.Get<string>("p_password"),
                Imagepath = p.Get<string>("p_ImagePath")
            };

            return user;
        }


        // Update Profile Method
        public void UpdateUserProfile(Userr user)
        {
            var p = new DynamicParameters();
            p.Add("p_userID", user.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_Fname", user.Fname, DbType.String, ParameterDirection.Input);
            p.Add("p_Lname", user.Lname, DbType.String, ParameterDirection.Input);
            p.Add("p_email", user.Email, DbType.String, ParameterDirection.Input);
            p.Add("p_password", user.Password, DbType.String, ParameterDirection.Input);
            p.Add("p_ImagePath", user.Imagepath, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute("UPDATE_USER_PROFILE", p, commandType: CommandType.StoredProcedure);
        }





    }
}
