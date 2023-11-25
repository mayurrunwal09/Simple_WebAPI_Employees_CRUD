using Domain.Model;
using Domain.ViewModels;
using Infrastructure.Services.Custom_Services.EmployeeServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet(nameof(GetAllEmployee))]
        public async Task<ActionResult<EmployeeViewModel>> GetAllEmployee()
        {
            var result = await _service.GetAll();
            if (result == null)
                return BadRequest("No Records Found, Please Try Again After Adding them...!");
            return Ok(result);

        }

        [HttpGet(nameof(GetEmployee))]
        public async Task<IActionResult> GetEmployee(int Id)
        {
            if (Id != null)
            {
                var result = await _service.GetById(Id);
                if (result == null)
                    return BadRequest("No Records Found, Please Try Again After Adding them...!");
                return Ok(result);
            }
            else
                return NotFound("Invalid Supplier Id, Please Entering a Valid One...!");
        }

        [HttpPost(nameof(AddEmployee))]
        public async Task<IActionResult> AddEmployee([FromForm] EmployeeInsertModel itemModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Insert(itemModel);
                if (result == true)
                    return Ok("Category Inserted Successfully...!");
                else
                    return BadRequest("Something Went Wrong, Category Is Not Inserted, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Category Information, Please Entering a Valid One...!");
        }

        [HttpPut(nameof(UpdateEmployee))]
        public async Task<IActionResult> UpdateEmployee([FromForm] EmployeeUpdateModel itemModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Update(itemModel);
                if (result == true)
                    return Ok(itemModel);
                else
                    return BadRequest("Something Went Wrong, Category Is Not Inserted, Please Try After Sometime...!");
            }
            else
                return BadRequest("Invalid Category Information, Please Entering a Valid One...!");
        }


        [HttpDelete(nameof(DeleteEmployee))]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            var result = await _service.Delete(Id);
            if (result == true)
                return Ok("Supplier Deleted Successfully...!");
            else
                return BadRequest("Something Went Wrong, Supplier Is Not Deleted, Please Try After Sometime...!");
        }
    }
}
