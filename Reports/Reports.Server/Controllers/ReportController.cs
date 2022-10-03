using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;
        
        public ReportController(IReportService service)
        {
            _service = service;
        }
        
        [HttpPost("create")]
        public async Task<ReportModel> Create([FromQuery] string taskId, [FromQuery] string employeeId)
        {
            return await _service.Create(taskId, employeeId, DateTime.MinValue, DateTime.MaxValue);
        }
        
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromQuery] ReportModel entity)
        {
            await _service.Update(entity);
            return Ok();
        }
        
        [HttpGet("findAllTaskOfTeam")]
        public async Task<List<TaskModel>> FindAllTaskOfTeam([FromQuery] string employeeId)
        {
            var result = await _service.FindAllTaskOfTeam(employeeId);
            return result;
        }
    }
}