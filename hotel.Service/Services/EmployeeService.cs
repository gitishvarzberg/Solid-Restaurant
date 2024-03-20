using Restaurant.Core.Models;
using Restaurant.Core.Repositories;
using Restaurant.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        Employee IEmployeeService.AddEmployee(Employee employee)
        {
          return _employeeRepository.AddEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }

        IEnumerable<Employee> IEmployeeService.GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        Employee IEmployeeService.GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        Employee IEmployeeService.UpdateEmployee(int id, Employee employee)
        {
            return _employeeRepository.UpdateEmployee(id, employee);
        }
    }
}
