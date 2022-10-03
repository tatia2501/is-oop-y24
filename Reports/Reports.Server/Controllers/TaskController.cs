using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;
using TaskStatus = Reports.DAL.Entities.TaskStatus;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        
        public TaskController(ITaskService service)
        {
            _service = service;
        }
        
        [HttpPost("create")]
        public async Task<TaskModel> Create([FromQuery] string name, [FromQuery] string employeeId)
        {
            return await _service.Create(name, employeeId, DateTime.Now);
        }
        
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromQuery] TaskModel entity)
        {
            await _service.Update(entity);
            return Ok();
        }

        [HttpGet("FindbyId")]
        public async Task<TaskModel> FindbyId([FromQuery] Guid id)
        {
            var result = await _service.FindById(id);
            return result;
        }

        [HttpGet("FindbyStartTime")]
        public async Task<TaskModel> FindbyStartTime([FromQuery] DateTime time)
        {
            var result = await _service.FindByStartTime(time);
            return result;
        }
        
        [HttpGet("FindbyLastChange")]
        public async Task<TaskModel> FindbyLastChangeTime([FromQuery] DateTime time)
        {
            var result = await _service.FindByLastChangeTime(time);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<List<TaskModel>> GetAllByEmployeeId([FromQuery] string employeeId)
        {
            var result = await _service.GetAllByEmployeeId(employeeId);
            return result;
        }
    }
}