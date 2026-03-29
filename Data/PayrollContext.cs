using Microsoft.EntityFrameworkCore;
using MvcPayroll.Models;

namespace MvcPayroll.Data
{
    public class PayrollContext : DbContext
    {
        public PayrollContext(DbContextOptions<PayrollContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
