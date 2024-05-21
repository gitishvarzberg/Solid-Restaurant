using Restaurant.Core.DTOs;
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
        Task<Employee> AddEmployeeAsync(Employee Employee);
        Task DeleteEmployeeAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> UpdateEmployeeAsync(int id, Employee Employee);
    }
}
