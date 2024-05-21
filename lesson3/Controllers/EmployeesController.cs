using Restaurant.Core.Models;
using Restaurant.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Services;
using lesson3.models;
using AutoMapper;
using Restaurant.Core.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeService employeeService,IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }


        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task< ActionResult> Get()
        {
            var employees =await _employeeService.GetEmployeesAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDTOs>>(employees));
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task< ActionResult> Get(int id)
        {   
            var employee =await _employeeService.GetEmployeeByIdAsync(id);
            var employeeDTOs=_mapper.Map<EmployeeDTOs>(employee);   
            return Ok(employeeDTOs);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task< ActionResult> Post([FromBody] EmployeePostModel employee)
        {
            var employeeToAdd =await _employeeService.AddEmployeeAsync(_mapper.Map<Employee>(employee));
             return Ok(_mapper.Map<EmployeeDTOs>(employeeToAdd));
                
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task < ActionResult> Put(int id, [FromBody] EmployeePostModel employee)
        {
            var employeeTemp = await _employeeService.GetEmployeeByIdAsync(id);
            if (employeeTemp is null)
            {
                return NotFound();
            }
            _mapper.Map(employee, employeeTemp);
            await _employeeService.UpdateEmployeeAsync(id, _mapper.Map<Employee>(employee));
            employeeTemp = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(_mapper.Map<EmployeeDTOs>(employeeTemp));
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee is null)
            {
                return NotFound();
            }

            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
