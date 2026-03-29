using Microsoft.AspNetCore.Mvc;
using MvcPayroll.Models;

namespace MvcPayroll.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetActiveEmployees();
        Employee? GetEmployeeById(int id);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeactivateEmployee(int id);
    }
}
