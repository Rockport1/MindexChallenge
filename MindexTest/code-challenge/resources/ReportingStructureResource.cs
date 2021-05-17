using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.resources
{
    public class ReportingStructureResource
    {
        public String EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int NumberOfReports { get; set; }
        public List<ReportingStructureResource> DirectReportStructList { get; set; }
    }
}
