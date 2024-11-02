using CharityWebsite.Core.Common;
using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.Common;

namespace CharityWebsite.Infra.Repository
{
    public class ProblemreportRepository : IProblemreportRepository
    {
        
     
        private readonly IDbContext dBContext;
        public ProblemreportRepository(IDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        // Retrieve all problem reports
        public List<Problemreport> GetAllProblemReports()
        {
            IEnumerable<Problemreport> result = 
                dBContext.Connection.Query<Problemreport>("ProblemReport_Package.GetAllProblemReports",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        // Retrieve a problem report by ID
        public Problemreport GetProblemReportById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, DbType.Int32, ParameterDirection.Input);
            IEnumerable<Problemreport> result = 
                dBContext.Connection.Query<Problemreport>("ProblemReport_Package.GetProblemReportById", 
                p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        // Create a new problem report
        public void CreateProblemReport(Problemreport problemReport)
        {
            var p = new DynamicParameters();
            p.Add("description", problemReport.Description, DbType.String, ParameterDirection.Input);
            p.Add("ImagePath", problemReport.Imagepath, DbType.String, ParameterDirection.Input);
            p.Add("Status", problemReport.Status ?? "Pending", DbType.String, ParameterDirection.Input); // Default to 'Pending'
            p.Add("ProblemType", problemReport.Problemtype, DbType.String, ParameterDirection.Input);
            p.Add("userID", problemReport.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("CharityID", problemReport.Charityid, DbType.Int32, ParameterDirection.Input);

            dBContext.Connection.Execute("ProblemReport_Package.CreateProblemReport", p, commandType: CommandType.StoredProcedure);
        }

        // Update an existing problem report
        public void UpdateProblemReport(Problemreport problemReport)
        {
            var p = new DynamicParameters();
            p.Add("id", problemReport.Problemreportid, DbType.Int32, ParameterDirection.Input);
            p.Add("description", problemReport.Description, DbType.String, ParameterDirection.Input);
            p.Add("ImagePath", problemReport.Imagepath, DbType.String, ParameterDirection.Input);
            p.Add("Status", problemReport.Status, DbType.String, ParameterDirection.Input);
            p.Add("ProblemType", problemReport.Problemtype, DbType.String, ParameterDirection.Input);
            p.Add("CharityID", problemReport.Charityid, DbType.Int32, ParameterDirection.Input);

            dBContext.Connection.Execute("ProblemReport_Package.UpdateProblemReport", p, commandType: CommandType.StoredProcedure);
        }

        // Delete a problem report by ID
        public void DeleteProblemReport(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, DbType.Int32, ParameterDirection.Input);
            dBContext.Connection.Execute("ProblemReport_Package.DeleteProblemReport", p, commandType: CommandType.StoredProcedure);
        }

        // Example search by problem type
        public List<Problemreport> SearchProblemReportsByType(string problemType)
        {
            var query = "SELECT * FROM PROBLEMREPORT WHERE LOWER(ProblemType) LIKE LOWER(:ProblemType)";
            var parameters = new DynamicParameters();
            parameters.Add("ProblemType", $"%{problemType}%", DbType.String);

            IEnumerable<Problemreport> result = dBContext.Connection.Query<Problemreport>(query, parameters);
            return result.ToList();
        }
    }

    }











