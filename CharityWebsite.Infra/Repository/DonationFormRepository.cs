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
    public class DonationFormRepository : IDonationFormRepository
    {
        private readonly IDbContext _dbContext;

        public DonationFormRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Donationform> GetAllDonationForms()
        {
            return _dbContext.Connection.Query<Donationform>("DONATIONFORM_PACKAGE.GETALLDONATIONFORMS", commandType: CommandType.StoredProcedure).ToList();
        }

        public Donationform GetDonationFormById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return _dbContext.Connection.Query<Donationform>("DONATIONFORM_PACKAGE.GETDONATIONFORMBYID", p, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }

        public void CreateDonationForm(Donationform donationForm)
        {
            var p = new DynamicParameters();
            p.Add("OBJECTNAME", donationForm.Objectname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESCRIPTION", donationForm.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEPATH", donationForm.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STATUS", donationForm.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CHARITYID", donationForm.Charityid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("DONATIONFORM_PACKAGE.CREATEDONATIONFORM", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateDonationForm(Donationform donationForm)
        {
            var p = new DynamicParameters();
            p.Add("ID", donationForm.Donationformid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NEW_OBJECTNAME", donationForm.Objectname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("NEW_DESCRIPTION", donationForm.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("NEW_IMAGEPATH", donationForm.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("NEW_STATUS", donationForm.Status, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("DONATIONFORM_PACKAGE.UPDATEDONATIONFORM", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteDonationFormById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("DONATIONFORM_PACKAGE.DELETEDONATIONFORM", p, commandType: CommandType.StoredProcedure);
        }

    }
}
