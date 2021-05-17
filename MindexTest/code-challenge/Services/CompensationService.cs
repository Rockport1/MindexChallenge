using challenge.Models;
using challenge.Repositories;
using challenge.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace challenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompensationService(ICompensationRepository compensationRepository, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _compensationRepository = compensationRepository;
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public Compensation GetById(String id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _compensationRepository.GetById(id);
            }

            return null;
        }

        public SaveCompensationResponse Create(Compensation compensation)
        {
            string msg;
            if (compensation != null)
            {
                // Some preliminary error checking, fills an error repsonse.
                if (!string.IsNullOrWhiteSpace(compensation.EmployeeId))
                {
                    if (_compensationRepository.GetById(compensation.EmployeeId) != null)
                    {
                        return new SaveCompensationResponse($"The Compensation Id: {compensation.EmployeeId} already exists.");
                    }

                    if (_employeeRepository.GetById(compensation.EmployeeId) == null)
                    {
                        return new SaveCompensationResponse($"An employee with Employee Id: {compensation.EmployeeId} does not exist.");
                    }

                    // Okay, thinkgs look good enough to reasonable attempt a save.  We'll follow a simple Unit of Work pattern
                    // to get everything saved.
                    var newCompensation = _compensationRepository.Add(compensation);
                    if (newCompensation != null)
                    {
                        try
                        {
                            _unitOfWork.Complete();

                            // Since it saved, fill in a success response
                            return new SaveCompensationResponse(newCompensation);
                        }
                        catch (Exception ex)
                        {
                            msg = $"An error occurred while saving the compensation: {ex.Message}";
                        }
                    }
                    else
                    {
                        msg = "An error occurred while saving the compensation";
                    }
                }
                else
                {
                    msg = "The EmployeeId must be a valid string, it can not be empty.";
                }
            }
            else
            {
                msg = "The Compensation object passed can not be null.";
            }

            // Things went south so fill an error response with appropriate message.
            return new SaveCompensationResponse(msg);
        }

    }
}
