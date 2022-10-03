using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IEmployeeService
    {
        Task<Employee> Create(string name, string leaderId);

        Task<Employee> FindById(Guid id);

        Task<Employee> Delete(Guid id);

        Task Update(Employee entity);
        Task<List<Employee>> GetAll();
    }
}