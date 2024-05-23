using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solid.API.Models;
using Solid.core;
using Solid.core.DTOs;
using Solid.core.Enentities;
using Solid.core.Repositories;
using Solid.core.Services;
using Solid.service.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _iemployeeService;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeService iemployeeService, IMapper mapper)
        {
            _iemployeeService = iemployeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var employees = await _iemployeeService.GetListAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }
        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(long id)
        {
            var employee = await _iemployeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound("עובד לא קיים במערכת"); 
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }
        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] EmployeePostModel employee)
        {
            if (employee.Id>999999999||employee.Id<0)
                return BadRequest("מספר תעודת הזהות אינו תקין");

            var newEmployee = await _iemployeeService.AddAsync(_mapper.Map<Employee>(employee));
            return Ok(_mapper.Map<EmployeeDto>(newEmployee));
        }
        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(long id, [FromBody] EmployeePostModel employeeModel)
        {
            var employee = await _iemployeeService.GetByIdAsync(id);
            if (employee is null)
                return NotFound("עובד לא קיים במערכת");
            _mapper.Map(employeeModel, employee);
            await _iemployeeService.UpdateAsync(employee, id);
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            var employee = await _iemployeeService.GetByIdAsync(id);
            if (employee is null)
                return NotFound("עובד לא קיים במערכת");
            await _iemployeeService.DeleteAsync(id);
            return NoContent();
        }
    }
}







