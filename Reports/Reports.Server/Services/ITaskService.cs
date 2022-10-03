using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.DAL.Entities;
using TaskStatus = Reports.DAL.Entities.TaskStatus;

namespace Reports.Server.Services
{
    public interface ITaskService
    {
        Task<TaskModel> Create(string name, string employeeId, DateTime startdate);

        Task<TaskModel> FindById(Guid id);

        Task<TaskModel> FindByStartTime(DateTime time);

        Task<TaskModel> FindByLastChangeTime(DateTime time);

        Task<List<TaskModel>> GetAllByEmployeeId(string employeeId);
        Task Update(TaskModel entity);
    }
}