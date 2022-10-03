using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Repositories
{
    public class EmployeeRepository
    {
        private readonly ReportsDatabaseContext _context;
        
        public EmployeeRepository(ReportsDatabaseContext context) {
            _context = context;
        }
        
        public async Task Create(Employee employee)
        {
            var employeeFromDb = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> FindById(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task<Employee> Delete(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            await Task.Run(() => _context.Employees.Remove(employee));
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task Update(Employee entity)
        {
            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }
    }
}