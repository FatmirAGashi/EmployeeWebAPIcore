using EmployeeWebAPIcore.Models;
using EmployeeWebAPIcore.Respository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPIcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository _employeeRepository)
        {
            this.employeeRepository = _employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await employeeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetAEmploye(int id)
        {
            return await employeeRepository.GetOneEmployee(id);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostAEmployee([FromBody] Employee employee)
        {
            var newEmployee = await employeeRepository.CreateEmployee(employee);
            return CreatedAtAction(nameof(GetAllEmployees), new { id = newEmployee.EmployeeID }, newEmployee);
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> PutAEmployee(int id, [FromBody] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }
            await employeeRepository.Update(employee);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAEmployee(int id)
        {
            var studentToDelete = await employeeRepository.GetOneEmployee(id);
            if (studentToDelete == null)
            {
                return NotFound();
            }
            await employeeRepository.DeleteEmployee(studentToDelete.EmployeeID);
            return NoContent();
        }

    }
}
