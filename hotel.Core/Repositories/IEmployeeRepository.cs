using Restaurant.Core.Models;

namespace Restaurant.Core.Repositories
{
    public interface IEmployeeRepository
    {
         Task<Employee> AddEmployeeAsync(Employee Employee);
         Task DeleteEmployeeAsync(int id);
         Task<IEnumerable<Employee>> GetEmployeesAsync();
         Task<Employee> GetEmployeeByIdAsync(int id);
         Task<Employee> UpdateEmployeeAsync(int id, Employee Employee);
        
    }
}
