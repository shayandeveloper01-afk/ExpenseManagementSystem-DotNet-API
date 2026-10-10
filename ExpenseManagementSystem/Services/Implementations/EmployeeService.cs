using ExpenseManagementSystem.Services.Interfaces;
using ExpenseManagementSystem.Repositories.Interfaces;
using ExpenseManagementSystem.Models;

namespace ExpenseManagementSystem.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<CompanyExpense>> GetAllData()
        {
            var employee = await _employeeRepository.GetAllData();
            return employee;
        }

        public async Task<CompanyExpense> GetAllDatabyId(int id)
        {
            var employeebyid = await _employeeRepository.GetAllDatabyId(id);
            return employeebyid;
        }

        public async Task<bool> AddEmployeeData(CompanyExpense employee)
        {

            var insertdata = await _employeeRepository.AddEmployeeData(employee);
            return insertdata;
        }

        public async Task<bool> UpdateEmployeeData(int id, CompanyExpenseUpdatedData CompanyExpenseUpdatedData)
        {
            var updatedata = await _employeeRepository.UpdateEmployeeData(id, CompanyExpenseUpdatedData);
            return updatedata;  
        }

        public async Task<bool> DeleteEmployeeData(int id)
        {
            var deletedata = await _employeeRepository.DeleteEmployeeData(id);
            return deletedata;
        }
    }
}

    
