using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public interface IEmployeeService
    {
         Employee AddEmployee(Employee Employee);
         void DeleteEmployee(int id);
         IEnumerable<Employee> GetEmployees();
         Employee GetById(int id);
         Employee UpdateEmployee(int id, Employee Employee);
    }
}
