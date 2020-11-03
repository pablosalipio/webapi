using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Controllers;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private EmployeeService service;

        public EmployeesController(EmployeeContext context)
        {
            service = new EmployeeService(context);
        }

        // GET: api/Employees/5
        // retorna as informações do funcionario
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await service.GetEmployee(id);

            if (ModelState.IsValid && employee != null)
            {
                return employee;
            }
            else
            {
                ModelState.AddModelError("ID", "Não foi encontrado funcionario com o ID informado.");
                return BadRequest(ModelState);
            }
        }

        // POST: api/Employees
        // incluir funcionario
        // utiliza a classe Employee, validação pode ser consultada na classe EmployeeService
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (service.EmployeeExists(employee.Doc))
            {
                ModelState.AddModelError("Doc", "Já existe funcionario com o mesmo cpf cadastrado.");
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                service.PostEmployee(employee);
                await service.Save();
            }

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // GET: api/Employees/5
        // retorna o extrato salarial do funcionario
        [HttpGet("paycheck/{id}")]
        public async Task<ActionResult<Paycheck>> PayCheck(int id)
        {
            Employee employee = await service.GetEmployee(id);
            var paycheck = new PaycheckController();   

            if (employee == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("ID", "Não foi encontrado funcionario com o ID informado.");
                return BadRequest(ModelState);
            }
            else
            {
                return paycheck.PaycheckGet(employee);
            }
        }

        
    }
}
