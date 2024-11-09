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
    public class DonationRepository:IDonationRepository
    {

        private readonly IDbContext _dbContext;

        public DonationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void ProcessDonation(int userID, int charityID, decimal amount, string cardNumber, DateTime expiryDate, string cvv)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_userID", userID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_charityID", charityID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_amount", amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_cardNumber", cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("p_expiryDate", expiryDate, DbType.Date, ParameterDirection.Input);
            parameters.Add("p_cvv", cvv, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute("DonationPackage.ProcessDonation", parameters, commandType: CommandType.StoredProcedure);
        }


    }
   
  
}

