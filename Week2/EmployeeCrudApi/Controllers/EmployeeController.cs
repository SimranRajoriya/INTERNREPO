using Microsoft.AspNetCore.Mvc;
using EmployeeCrudApi.Models;
using EmployeeCrudApi.Services;

namespace EmployeeCrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            _service.Add(employee);
            return Ok("Employee Added");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee employee)
        {
            _service.Update(id, employee);
            return Ok("Employee Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Employee Deleted");
        }
    }
}