using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApiCRUD.Models;

namespace RestApiCRUD.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name= "Employee One",
                CPF = "15509174714"
            },
             new Employee()
            {
                Id = Guid.NewGuid(),
                Name= "Employee two",
                CPF = "15509174725"
            }
        };
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            existingEmployee.CPF = employee.CPF;
            return existingEmployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
          return employees;
        }
    }
}
