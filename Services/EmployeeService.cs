using Microsoft.AspNetCore.Http.HttpResults;
using MvcPayroll.Data;
using MvcPayroll.Models;

namespace MvcPayroll.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly PayrollContext _payrollContext;

        public EmployeeService(PayrollContext payrollContext)
        {
            _payrollContext = payrollContext;
        }
        public List<Employee> GetActiveEmployees()
        {
            return  _payrollContext.Employees.Where(e => e.IsActive).ToList();
        }

        public Employee? GetEmployeeById(int id)
        {
            return  _payrollContext.Employees.Find(id);
        }

        public void CreateEmployee(Employee employee)
        {
            _payrollContext.Employees.Add(employee);
            _payrollContext.SaveChanges();    
        }
        public void UpdateEmployee(Employee employee)
        {
            var emp = _payrollContext.Employees.Find(employee.Id);
            if(emp == null) return;

            emp.Name = employee.Name;
            emp.Department = employee.Department;
            emp.Office = employee.Office;
            emp.Location = employee.Location;
            emp.AnnualSalary = employee.AnnualSalary;
            emp.PayFrequency = employee.PayFrequency;
            emp.Email = employee.Email;

            _payrollContext.SaveChanges();            
        }
        

        public void DeactivateEmployee(int id)
        {
            var emp = _payrollContext.Employees.Find(id);

            if (emp == null) return;
            
            emp.IsActive =false;

            _payrollContext.SaveChanges();
        }


    }
}
