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
    public class LoginRepository: ILoginRepository
    {


        private readonly IDbContext _dbContext;
        public LoginRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        

        public Userr Auth(Userr userr)
        {
            var p = new DynamicParameters();
            p.Add("User_Email", userr.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("User_Password", userr.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            var rse = _dbContext.Connection.Query<Userr>("Login_Package.User_Login", p, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            return rse;
        }
    }
}
