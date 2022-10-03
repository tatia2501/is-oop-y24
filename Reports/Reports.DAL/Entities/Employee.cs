using System;

namespace Reports.DAL.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LeaderId { get; set; }

        public Employee()
        {
        }

        public Employee(Guid id, string name, string leaderId)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id), "Id is invalid");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name is invalid");
            }
            
            if (string.IsNullOrWhiteSpace(leaderId))
            {
                throw new ArgumentNullException(nameof(leaderId), "Leader ID is invalid");
            }

            Id = id;
            Name = name;
            LeaderId = leaderId;
        }
    }
}