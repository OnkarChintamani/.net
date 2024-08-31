using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeeById(int employeeId);

        int AddEmployee(Employee employee);

        int EditEmployee(Employee employee);

        int DeleteEmployee(int id);
    }
}
