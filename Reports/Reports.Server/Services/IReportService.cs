using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IReportService
    {
        Task<ReportModel> Create(string taskId, string employeeId, DateTime startDate, DateTime finishDate);
        Task Update(ReportModel entity);
        Task<List<TaskModel>> FindAllTaskOfTeam(string employeeId);
    }
}