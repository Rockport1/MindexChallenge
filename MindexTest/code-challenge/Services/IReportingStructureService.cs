using challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Services
{
    public interface IReportingStructureService
    {
        //Task<IEnumerable<ReportingStructure>> ListAsync();
        ReportingStructure GetById(String id);
        //Employee GetById(String id);

    }
}
