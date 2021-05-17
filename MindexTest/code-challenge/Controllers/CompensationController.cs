using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using challenge.Services;
using challenge.Models;
using challenge.resources;
using AutoMapper;
using Microsoft.Extensions.Logging;
using challenge.Extensions;
using challenge.Services.Communication;

namespace challenge.Controllers
{
    [Route("api/compensation")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;
        private readonly IMapper _mapper;

        public CompensationController(ILogger<ReportingStructureController> logger, ICompensationService compensationService, IMapper mapper)
        {
            _logger = logger;
            _compensationService = compensationService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] SaveCompensationResource compensationResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            // Map the incoming compensation data to a compensation object, this is the same structure we'll return.
            Compensation compensation = _mapper.Map<SaveCompensationResource, Compensation>(compensationResource);
            SaveCompensationResponse result = _compensationService.Create(compensation);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var compResource = _mapper.Map<Compensation, CompensationResource>(result.Compensation);
            return CreatedAtRoute("getCompensationById", new { id = compResource.EmployeeId }, compResource);
        }

        [HttpGet("{id}", Name = "getCompensationById")]
        public IActionResult GetCompensationById(String id)
        {
            _logger.LogDebug($"Received compensation get request for '{id}'");

            var compensation = _compensationService.GetById(id);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }

    }
}
