using Restaurant.Core.Models;

namespace Restaurant.Core.Repositories
{
    public interface IEmployeeRepository
    {
         Employee AddEmployee(Employee Employee);
         void DeleteEmployee(int id);
         IEnumerable<Employee> GetEmployees();
         Employee GetById(int id);
         Employee UpdateEmployee(int id, Employee Employee);
        
    }
}
