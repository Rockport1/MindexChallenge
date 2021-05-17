using challenge.Models;
using challenge.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Services
{
    public interface ICompensationService
    {
        Compensation GetById(String id);
        SaveCompensationResponse Create(Compensation compensation);
        //Compensation Create(Compensation compensation);
    }
}
