using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.DAL.Entities;
using Reports.Server.Database;
using Reports.Server.Repositories;

namespace Reports.Server.Services
{
    public class ReportService : IReportService
    {
        private ReportRepository _repository;

        public ReportService(ReportsDatabaseContext context) {
            _repository = new ReportRepository(context);
        }
        public async Task<ReportModel> Create(string taskId, string employeeId, DateTime startDate, DateTime finishDate)
        {
            var report = new ReportModel(Guid.NewGuid(), taskId, employeeId, startDate, finishDate);
            await _repository.Create(report);
            return report;
        }
        
        public async Task Update(ReportModel entity)
        {
            await _repository.Update(entity);
        }

        public async Task<List<TaskModel>> FindAllTaskOfTeam(string employeeId)
        {
            return await _repository.FindAllTaskOfTeam(employeeId);
        }
    }
}