using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace ExpenseManagementSystem.Models
{
    [Table("CompanyExpense")]
    public class CompanyExpense
    {
        [Key]
        public int CompanyExpenseid { get; set; }

        public string EmployeeName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Department { get; set; } = null!;

        public decimal Salary { get; set; }

        public bool  IsActive { get; set; }
    }
}