using Microsoft.AspNetCore.Mvc;
using MvcPayroll.Data;
using MvcPayroll.Models;
using MvcPayroll.Services;

namespace MvcPayroll.Controllers
{   
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController( IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var result = _employeeService.GetActiveEmployees();
            
            return View(result);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee) 
        {
            if (!ModelState.IsValid) { 
                return View();
            }

            _employeeService.CreateEmployee(employee);

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee) 
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            _employeeService.UpdateEmployee(employee);
            return RedirectToAction("index");
            
        }

        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeService.DeactivateEmployee(id);

            return RedirectToAction("index");
        }
    }
}