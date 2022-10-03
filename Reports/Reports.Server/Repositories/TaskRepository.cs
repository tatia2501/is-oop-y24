using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Repositories
{
    public class TaskRepository
    {
        private readonly ReportsDatabaseContext _context;
        
        public TaskRepository(ReportsDatabaseContext context) {
            _context = context;
        }

        public async Task Create(TaskModel task)
        {
            var taskFromDb = await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<TaskModel> FindById(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return task;
        }

        public async Task<TaskModel> FindByTime(DateTime time)
        {
            var task = await _context.Tasks.FindAsync(time);
            return task;
        }

        public async Task<List<TaskModel>> FindByEmployeeId(string employeeId)
        {
            var task = await _context.Tasks.ToListAsync();
            return task.FindAll(t => t.EmployeeId == employeeId);
        }

        public async Task Update(TaskModel entity)
        {
            _context.Tasks.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}