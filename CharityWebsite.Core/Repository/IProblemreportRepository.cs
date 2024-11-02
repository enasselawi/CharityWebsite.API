using CharityWebsite.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Repository
{
    public interface IProblemreportRepository
    {
        List<Problemreport> GetAllProblemReports();
        Problemreport GetProblemReportById(int id);
        void CreateProblemReport(Problemreport problemReport);
        void UpdateProblemReport(Problemreport problemReport);
        void DeleteProblemReport(int id);
        List<Problemreport> SearchProblemReportsByType(string problemType);
    }
}
