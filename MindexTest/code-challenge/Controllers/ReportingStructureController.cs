using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using challenge.Services;
using challenge.resources;
using Microsoft.AspNetCore.Mvc;
using challenge.Models;
using Microsoft.Extensions.Logging;

namespace challenge.Controllers
{
    [Route("api/reportingstructure")]
    public class ReportingStructureController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IReportingStructureService _reportingStructureService;

        public ReportingStructureController (ILogger<ReportingStructureController> logger, IReportingStructureService reportingStructureService, IMapper mapper)
        {
            _logger = logger;
            _reportingStructureService = reportingStructureService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "getReportingStructureById")]
        public IActionResult GetReportingStructureById(String id)
        {
            _logger.LogDebug($"Received reporting structure get request for '{id}'");
            
            var reportingStructure = _reportingStructureService.GetById(id);
            if (reportingStructure == null)
            {
                return NotFound();
            }

            // In this particular case the reporting structure and related resource are the same at
            // the moment so not strictly necessary.  Still, this allows for that to change in the 
            // future and ensure we only send back appropriate data regardless of what may be in the object.
            var resource = _mapper.Map<ReportingStructure, ReportingStructureResource>(reportingStructure);
            return Ok(resource);
        }
    }
}
