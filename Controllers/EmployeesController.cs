using Microsoft.AspNetCore.Mvc;

namespace MvcPayroll.Controllers
{   
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}