namespace ExpenseManagementSystem.Models
{
    public class CompanyExpenseUpdatedData
    {
        public string ? EmployeeName { get; set; } = null!;

        public string ? Email { get; set; } = null!;

        public string ? Phone { get; set; } = null!;

        public string ? Department { get; set; } = null!;

        public decimal ? Salary { get; set; }

        public bool ? IsActive { get; set; }
    }
}
