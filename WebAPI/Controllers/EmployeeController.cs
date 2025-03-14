﻿using BLL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;

        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await employee.GetAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await employee.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employeeDto)
        {
            var result = await employee.AddAsync(employeeDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employeeDto)
        {
            var result = await employee.UpdateAsync(employeeDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await employee.DeleteAsync(id);
            return Ok(data);
        }
    }
}
