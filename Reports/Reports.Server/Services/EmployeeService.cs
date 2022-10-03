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

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository _repository;

        public EmployeeService(ReportsDatabaseContext context) {
            _repository = new EmployeeRepository(context);
        }

        public async Task<Employee> Create(string name, string leaderId)
        {
            var employee = new Employee(Guid.NewGuid(), name, leaderId);
            await _repository.Create(employee);
            return employee;
        }

        public async Task<Employee> FindById(Guid id)
        {
            return await _repository.FindById(id);
        }

        public async Task<Employee> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task Update(Employee entity)
        {
            await _repository.Update(entity);
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}