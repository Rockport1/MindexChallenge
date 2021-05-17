using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    /// <summary>
    /// A reporting structure that holds an id (employee id) along with two fields (first and last name) 
    /// and the employee's number of direct reports. An object also has a list of reporting structures
    /// - one object for each direct report.  For consistency this is akin to the Employee class where 
    /// each employee has a list fo direct reports.  Here each reporting structure has a list of direct 
    /// report structures.  With this, the structure can be returned and processed by the caller.  We are
    /// not, however, including an entire Employee object in the Reporting Structure class since that may 
    /// become very large with many attributes, take longer to process and potentially return much more 
    /// information than is desirable.  To see an entire employee object may require higher security than 
    /// retrieving the reporting stucture.  Still, the first name and last anme are included as those would 
    /// typically be desirable when listing a reporting structure
    /// </summary>
    public class ReportingStructure
    {
        [Key]
        public String EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int NumberOfReports { get; set; }
        public List<ReportingStructure> DirectReportStructList { get; set; }
    }
}
