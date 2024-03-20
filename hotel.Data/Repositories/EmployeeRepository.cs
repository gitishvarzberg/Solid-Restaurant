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
        Employee IEmployeeRepository.AddEmployee(Employee Employee)
        {
            _context.Employees.Add(Employee);
            _context.SaveChanges();
            return Employee;

        }
        void IEmployeeRepository.DeleteEmployee(int id)
        {
            var temp = _context.Employees.Find(id);
            _context.Employees.Remove(temp);
            _context.SaveChanges();
        }
        IEnumerable<Employee> IEmployeeRepository.GetEmployees()
        {
            return _context.Employees;
        }
        Employee IEmployeeRepository.GetById(int id)
        {
            return _context.Employees.Find(id);

        }
        Employee IEmployeeRepository.UpdateEmployee(int id, Employee Employee)
        {
            var temp = _context.Employees.Find(id);
            temp.Name=Employee.Name;
            temp.PhoneNumber=Employee.PhoneNumber;
            temp.EmployeeId=id;
            _context.SaveChanges();
            return temp;
        }
    }
}
