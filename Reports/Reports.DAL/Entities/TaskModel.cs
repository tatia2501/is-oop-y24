using System;

namespace Reports.DAL.Entities
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string EmployeeId { get; set; }
        public DateTime StartDate  { get; set; }
        public DateTime LastActionDate  { get; set; }
        public DateTime FinishDate { get; set; }
        public string Comment { get; set; }

        public TaskModel()
        {
        }

        public TaskModel(Guid id, string name, TaskStatus status, string employeeId, DateTime startDate)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id), "Id is invalid");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name is invalid");
            }
            
            if (string.IsNullOrWhiteSpace(employeeId))
            {
                throw new ArgumentNullException(nameof(employeeId), "Employee ID is invalid");
            }

            Id = id;
            Name = name;
            Status = status;
            EmployeeId = employeeId;
            StartDate = startDate;
            LastActionDate = startDate;
            FinishDate = DateTime.MaxValue;
            Comment = "";
        }
    }
}