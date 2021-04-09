using EmployeeWebAPIcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPIcore.Respository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext employeeContext;

        public EmployeeRepository(EmployeeContext _employeeContext)
        {
            employeeContext = _employeeContext;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            employeeContext.Employees.Add(employee);
            await employeeContext.SaveChangesAsync();
            return employee;

        }

        public async Task DeleteEmployee(int id)
        {
            var employeeToDelete = await employeeContext.Employees.FindAsync(id);
            employeeContext.Employees.Remove(employeeToDelete);
            await employeeContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await employeeContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetOneEmployee(int id)
        {
            var studentToFind = await employeeContext.Employees.FindAsync(id);
            return studentToFind;
        }

        public async Task Update(Employee employee)
        {
            employeeContext.Entry(employee).State = EntityState.Modified;
            await employeeContext.SaveChangesAsync();
        }
    }
}
