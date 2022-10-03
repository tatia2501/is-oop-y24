using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Repositories
{
    public class ReportRepository
    {
        private readonly ReportsDatabaseContext _context;
        
        public ReportRepository(ReportsDatabaseContext context) {
            _context = context;
        }
        
        public async Task Create(ReportModel report)
        {
            var taskFromDb = await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
        }
        
        public async Task Update(ReportModel entity)
        {
            _context.Reports.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskModel>> FindAllTaskOfTeam(string employeeId)
        {
            
            var task = await _context.Tasks.ToListAsync();
            return task.FindAll(t => t.EmployeeId == employeeId);
        }
    }
}