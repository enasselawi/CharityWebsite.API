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
            var p = new DynamicParameters();
            p.Add("p_userID", userID, DbType.Int32, ParameterDirection.Input);
            p.Add("p_charityID", charityID, DbType.Int32, ParameterDirection.Input);
            p.Add("p_amount", amount, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_cardNumber", cardNumber, DbType.String, ParameterDirection.Input);
            p.Add("p_expiryDate", expiryDate, DbType.Date, ParameterDirection.Input);
            p.Add("p_cvv", cvv, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute("DonationPackage.ProcessDonation", p, commandType: CommandType.StoredProcedure);
        }
    }
   
    //public void ProcessDonation(int userId, int charityId, decimal amount, long cardNumber, DateTime expiryDate, int cvv)
    //{
    ////   _dbContext.OpenConnection(); // Open connection
    //    var p = new DynamicParameters();

    //    // Add parameters
    //    p.Add("p_userID", userId);
    //    p.Add("p_charityID", charityId);
    //    p.Add("p_amount", amount);
    //    p.Add("p_cardNumber", cardNumber);
    //    //p.Add("p_expiryDate", expiryDate);
    //    p.Add("p_expiryDate", expiryDate, DbType.Date);

    //    //p.Add("p_expiryDate", expiryDate.ToString("yyyy-MM-dd"), DbType.Date);

    //    p.Add("p_cvv", cvv);

    //    // Execute the stored procedure
    //    _dbContext.Connection.Execute("DonationPackage.ProcessDonation", p, commandType: CommandType.StoredProcedure);

    // // _dbContext.CloseConnection(); // Optionally close connection, or manage it outside
    //}
}

