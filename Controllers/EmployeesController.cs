using Microsoft.AspNetCore.Http.HttpResults;
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
                return View();
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();
            
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
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
            _context.Employees.Update(employee);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}