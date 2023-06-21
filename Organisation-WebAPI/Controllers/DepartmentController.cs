using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Organisation_WebAPI.Dtos.DepartmentDto;
using Organisation_WebAPI.Services.Departments;

namespace Organisation_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            
        }

        [HttpGet("GetAllDepartment")]
        public async Task<ActionResult<ServiceResponse<GetDepartmentDto>>> GetDepartments()
        {
            return Ok(await _departmentService.GetAllDepartments());
        }

        [HttpGet("GetDepartmentById")]
        public async Task<ActionResult<ServiceResponse<GetDepartmentDto>>> GetDepartment(int id)
        {
            return Ok(await _departmentService.GetDepartmentById(id));
        }

        [HttpPost("CreateDepartment")]
        public async Task<ActionResult<ServiceResponse<GetDepartmentDto>>> AddProduct(AddDepartmentDto newDepartment)
        {
            return Ok(await _departmentService.AddDepartment(newDepartment));
        }

        [HttpPut("UpdateDepartment")]
        public async Task<ActionResult<ServiceResponse<GetDepartmentDto>>> UpdateProduct(UpdateDepartmentDto updatedDepartment,int id){
            return Ok(await _departmentService.UpdateDepartment(updatedDepartment,id));
        }
        
        [HttpDelete("DeleteDepartment")]

        public async Task<ActionResult<ServiceResponse<GetDepartmentDto>>> DeleteProduct(int id){
            return Ok(await _departmentService.DeleteDepartment(id));
        }
    }
}