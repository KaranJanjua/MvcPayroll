using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPayroll.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true; // Default to active when created
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        public string? Department { get; set; }
        [Required]
        public string? Office { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        [Display(Name = "Annual Salary")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 9999999)]
        public decimal AnnualSalary { get; set; }
        [Required]
        [Display(Name = "Pay Frequency")]
        public PayFrequency PayFrequency { get; set; }
        [Required]
        [Display(Name = "Bank Account Number")]
        [StringLength(10, MinimumLength = 6)]
        public string? BankAccountNumber { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(125)]
        public string? Email { get; set; }
    }

    public enum PayFrequency 
    {
        Weekly = 1,
        Fortnightly = 2,
        Monthly = 3,
    }
}
