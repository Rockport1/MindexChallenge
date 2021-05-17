using challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Services.Communication
{
    /// <summary>
    /// Class to hold a repsonse for a compansation object.  One constructor takes a string and us used for
    /// error responses.  The  other public constructor takes a Compensation object and represents a success response
    /// 
    /// Can this be turned into a generic so it can work for any class and be a general saveResponse class?  For the next story...
    /// </summary>
    public class SaveCompensationResponse
    {
        public Compensation Compensation { get; private set; }
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        private SaveCompensationResponse(bool success, string message, Compensation compensation)
        {
            Success = success;
            Message = message;
            Compensation = compensation;
        }

        /// <summary>
        /// Create a success response
        /// </summary>
        /// <param name="compensation"></param>
        public SaveCompensationResponse(Compensation compensation) : this(true, string.Empty, compensation)
        { 
        }

        /// <summary>
        /// Create an error response
        /// </summary>
        /// <param name="message"></param>
        public SaveCompensationResponse(string message) : this(false, message, null)
        { 
        }

    }
}

