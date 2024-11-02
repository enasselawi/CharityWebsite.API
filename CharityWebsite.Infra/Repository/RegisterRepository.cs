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
   public class RegisterRepository : IRegisterRepository
    {
        private readonly IDbContext dBContext;
        public RegisterRepository(IDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void Register(Userr user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Fname", user.Fname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_Lname", user.Lname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_Email", user.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("p_Password", user.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("p_Imagepath", user.Imagepath, DbType.String, ParameterDirection.Input);

            dBContext.Connection.Execute("Register_Package.Register_User", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
