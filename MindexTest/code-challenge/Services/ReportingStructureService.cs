using challenge.Models;
using challenge.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ReportingStructureService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ReportingStructure GetById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                Employee emp = _employeeRepository.GetById(id);
                int directRptCount = DirectReportCount(emp);

                // This may not be necessary pending clarification of requirements.  On the likelyhood this
                // this is desired in the requirements we adding it now.
                ReportingStructure rptStructure = MakeReportingStructure(emp, DirectReportCount(emp));
                return rptStructure;
            }

            return null;
        }
 
        /// <summary>
        /// Calculate a count of the employees direct reports
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        private int DirectReportCount(Employee emp)
        {
            int directRptCount = 0;
            if (emp.DirectReports != null)
            {
                directRptCount = emp.DirectReports.Count();
                foreach (Employee e in emp.DirectReports)
                {
                    directRptCount += DirectReportCount(e);
                }
            }
            return directRptCount;
        }

        /// <summary>
        /// Create a reporting structure fo rth ecurrent employee and then build
        /// out a list of the reporting structures for direct reports.
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="rptCount"></param>
        /// <returns></returns>
        private ReportingStructure MakeReportingStructure(Employee emp, int rptCount)
        {
            ReportingStructure rptStructure = new ReportingStructure
            {
                EmployeeId = emp.EmployeeId,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                NumberOfReports = rptCount,
                DirectReportStructList = new List<ReportingStructure>()
            };

            if (emp.DirectReports != null)
            {
                foreach (Employee e in emp.DirectReports)
                {
                    int drCnt = DirectReportCount(e);
                    ReportingStructure rs = MakeReportingStructure(e, drCnt);
                    rptStructure.DirectReportStructList.Add(rs);
                    //rptStructure.DirectReportStructList.Add(MakeReportingStructure(e, DirectReportCount(e)));
                }
            }

            return rptStructure;
        }
    }
}
