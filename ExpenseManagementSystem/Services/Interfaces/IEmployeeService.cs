using ExpenseManagementSystem.Models;

namespace ExpenseManagementSystem.Services.Interfaces
{
    public interface IEmployeeService
    {
       public Task<IEnumerable<CompanyExpense>> GetAllData();

        public Task<CompanyExpense> GetAllDatabyId(int id);

        public Task<bool> AddEmployeeData(CompanyExpense employee);

        public Task<bool> UpdateEmployeeData(int id, CompanyExpenseUpdatedData CompanyExpenseUpdatedData);

        public Task<bool> DeleteEmployeeData(int id);
    }
}
