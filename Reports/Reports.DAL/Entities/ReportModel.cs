using System;

namespace Reports.DAL.Entities
{
    public class ReportModel
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; }
        public string TaskId { get; set; }
        public DateTime StartDate  { get; set; }
        public DateTime FinishDate { get; set; }

        public ReportModel()
        {
        }
        
        public ReportModel(Guid id, string employeeId, string taskId, DateTime startDate, DateTime finishDate)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id), "Id is invalid");
            }

            if (string.IsNullOrWhiteSpace(employeeId))
            {
                throw new ArgumentNullException(nameof(employeeId), "Employee ID is invalid");
            }
            
            if (string.IsNullOrWhiteSpace(taskId))
            {
                throw new ArgumentNullException(nameof(taskId), "Task ID is invalid");
            }

            Id = id;
            EmployeeId = employeeId;
            TaskId = taskId;
            StartDate = startDate;
            FinishDate = finishDate;
        }
    }
}