using CharityWebsite.Core.Common;
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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbContext _dbContext;

        public PaymentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void PayForPost(int userId, int charityId, decimal amount, long cardNumber, DateTime expiryDate, int cvv)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_userID", userId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_charityID", charityId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_amount", amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_cardNumber", cardNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("p_expiryDate", expiryDate, DbType.Date, ParameterDirection.Input);
            parameters.Add("p_cvv", cvv, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("PAYMENT_PACKAGE.PAY_FOR_POST", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
