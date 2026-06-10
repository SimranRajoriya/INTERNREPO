using EmployeeCrudApi.Models;

namespace EmployeeCrudApi.Services
{
    public class EmployeeService
    {
        private static List<Employee> employees = new()
        {
            new Employee
            {
                Id = 1,
                Name = "Simran",
                Department = "IT",
                Salary = 50000
            }
        };

        public List<Employee> GetAll()
        {
            return employees;
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public void Update(int id, Employee employee)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Department = employee.Department;
                emp.Salary = employee.Salary;
            }
        }

        public void Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                employees.Remove(emp);
            }
        }
    }
}