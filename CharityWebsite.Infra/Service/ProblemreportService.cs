using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using CharityWebsite.Core.Service;
using CharityWebsite.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Infra.Service
{
    public class ProblemreportService : IProblemreportService
    {
        private readonly IProblemreportRepository problemreportRepository;
        public ProblemreportService(IProblemreportRepository problemreportRepository)
        {
            this.problemreportRepository = problemreportRepository;
        }

        public List<Problemreport> GetAllProblemReports()
        {
            return problemreportRepository.GetAllProblemReports();
        }

        public Problemreport GetProblemReportById(int id)
        {
            return problemreportRepository.GetProblemReportById(id);
        }

        public void CreateProblemReport(Problemreport problemReport)
        {
            problemreportRepository.CreateProblemReport(problemReport);
        }

        public void UpdateProblemReport(Problemreport problemReport)
        {
            problemreportRepository.UpdateProblemReport(problemReport);
        }

        public void DeleteProblemReport(int id)
        {
            problemreportRepository.DeleteProblemReport(id);
        }

        public List<Problemreport> SearchProblemReportsByType(string problemType)
        {
            return problemreportRepository.SearchProblemReportsByType(problemType);
        }



    }



}

