using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Models;
using Restaurant.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
   

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var temp = await GetEmployeeByIdAsync(id);
            _context.Employees.Remove(temp);
            _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FirstAsync(x => x.EmployeeId == id);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee Employee)
        {

            var temp = await GetEmployeeByIdAsync(id);
            temp.Name = Employee.Name;
            temp.PhoneNumber = Employee.PhoneNumber;
            temp.EmployeeId = id;
            await _context.SaveChangesAsync();
            return temp;
     
        }
    }
}
