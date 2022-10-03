using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reports.DAL.Entities;
using Reports.Server.Controllers;
using Reports.Server.Database;
using Reports.Server.Repositories;
using TaskStatus = Reports.DAL.Entities.TaskStatus;

namespace Reports.Server.Services
{
    public class TaskService : ITaskService
    {
        private TaskRepository _repository;

        public TaskService(ReportsDatabaseContext context) {
            _repository = new TaskRepository(context);
        }

        public async Task<TaskModel> Create(string name, string employeeId, DateTime startdate)
        {
            var task = new TaskModel(Guid.NewGuid(), name, TaskStatus.open, employeeId, startdate);
            await _repository.Create(task);
            return task;
        }

        public async Task<TaskModel> FindById(Guid id)
        {
            return await _repository.FindById(id);
        }
        
        public async Task<TaskModel> FindByStartTime(DateTime time)
        {
            return await _repository.FindByTime(time);
        }
        
        public async Task<TaskModel> FindByLastChangeTime(DateTime time)
        {
            return await _repository.FindByTime(time);
        }

        public async Task<List<TaskModel>> GetAllByEmployeeId(string employeeId)
        {
            return await _repository.FindByEmployeeId(employeeId);
        }
        
        public async Task Update(TaskModel entity)
        {
            await _repository.Update(entity);
        }
    }
}