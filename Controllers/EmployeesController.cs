using Microsoft.AspNetCore.Mvc;
using MvcPayroll.Data;
using MvcPayroll.Models;
using System.ComponentModel.DataAnnotations;

namespace MvcPayroll.Controllers
{   
    public class EmployeesController : Controller
    {
        private readonly PayrollContext _context;
        public EmployeesController( PayrollContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employee = _context.Employees.ToList();
            return View(employee);
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
                return Content("Validation failed: " + 
                    string.Join(", ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)));
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();
            
            return RedirectToAction("index");
        }
    }
}