using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ExpenseManagementSystem.Models;
using ExpenseManagementSystem.Repositories.Interfaces;
using System.Reflection.Metadata.Ecma335;
namespace ExpenseManagementSystem.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionstring;


        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection")!;
        }


        public async Task<IEnumerable<CompanyExpense>> GetAllData()
        {
            using var connection = new SqlConnection(_connectionstring);

            var employee = await connection.GetAllAsync<CompanyExpense>();

            return employee;
        }

        public async Task<CompanyExpense> GetAllDatabyId(int id)
        {
            using var connection = new SqlConnection(_connectionstring);

            var employeebyid = await connection.GetAsync<CompanyExpense>(id);
            return employeebyid;
        }

        public async Task<bool> AddEmployeeData(CompanyExpense employee)
        {
            using var connection = new SqlConnection(_connectionstring);

            var insertdata =await connection.InsertAsync(employee);
            return insertdata > 0;
        }

        public async Task<bool> UpdateEmployeeData(int id, CompanyExpenseUpdatedData CompanyExpenseUpdatedData)
        {
            using var connection = new SqlConnection(_connectionstring);
            var olddata = await connection.GetAsync<CompanyExpense>(id);

            if (olddata == null)
            {
                return false;
            }


            if (CompanyExpenseUpdatedData.EmployeeName != null)
            {
                olddata.EmployeeName = CompanyExpenseUpdatedData.EmployeeName;
            }

            if(CompanyExpenseUpdatedData.Email != null)
            {
                olddata.Email = CompanyExpenseUpdatedData.Email;
            }

            if(CompanyExpenseUpdatedData.Phone != null)
            {
                olddata.Phone = CompanyExpenseUpdatedData.Phone;
            }

            if(CompanyExpenseUpdatedData.Department != null)
            {
                olddata.Department = CompanyExpenseUpdatedData.Department;
            }

            if(CompanyExpenseUpdatedData.Salary.HasValue)
            {
                olddata.Salary = CompanyExpenseUpdatedData.Salary.Value;
            }

            if (CompanyExpenseUpdatedData.IsActive != null)
            {
                olddata.IsActive = CompanyExpenseUpdatedData.IsActive.Value;
            }

            var updatedata = await connection.UpdateAsync(olddata);
            return updatedata;
        }

        public async Task<bool> DeleteEmployeeData(int id)
        {
            using var connection = new SqlConnection(_connectionstring);
            var deletebyid = await connection.GetAsync<CompanyExpense>(id);
            if (deletebyid == null)
            {
                return false;
            }

            var deletedata = await connection.DeleteAsync(deletebyid);
            return deletedata;
        }
    }
}

      