using ExpenseManagementSystem.Models;
using ExpenseManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService EmployeeService)
        {
            _employeeService = EmployeeService;
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAllData()
        {
            var employee = await _employeeService.GetAllData();
            return Ok(employee);


        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDatabyId(int id)
        {
            var employeebyid = await _employeeService.GetAllDatabyId(id);
            return Ok(employeebyid);
        }




        [HttpPost("create")]
        public async Task<IActionResult> AddEmployeeData(CompanyExpense employee)
        {
            var insertdata = await _employeeService.AddEmployeeData(employee);
            if (!insertdata)
            {
                return BadRequest("Data Insertion Failed");

            }

            return Ok("Data Inserted Successfully");

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateData(int id,[FromBody] CompanyExpenseUpdatedData CompanyExpenseUpdatedData)
        {
            var updatedata = await _employeeService.UpdateEmployeeData(id, CompanyExpenseUpdatedData);
            if (!updatedata)
            {
                return BadRequest("Data Update Failed");

            }

            return Ok("Data Inserted Successfully");


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {


            var deletedata = await _employeeService.DeleteEmployeeData(id);
            if (!deletedata)
            {
                return BadRequest("Data Deleted Failed");

            }

            return Ok("Data Deleted Successfully");



        }









        //[HttpGet("all")]
        //public IActionResult Getmsg()
        //{
        //    return BadRequest("Hello from EmployeeController");
        //}

        //[HttpGet("first")]
        //public IActionResult GetFirstEmployee()
        //{
        //    return Ok("First Employee Data");
        //}
    }
}
