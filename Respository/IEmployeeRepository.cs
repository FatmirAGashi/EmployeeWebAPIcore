using EmployeeWebAPIcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPIcore.Respository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();

        Task<Employee> GetOneEmployee(int id);

        Task<Employee> CreateEmployee(Employee employee);

        Task Update(Employee employee);

        Task DeleteEmployee(int id);
    }
}
