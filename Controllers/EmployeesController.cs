using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using webapi.Models;
using webapi.Services;
using webapi.Services.Validator;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
            //service = new EmployeeService(context);

        }

        // GET: api/employees/{id}
        /// <summary>
        /// Retorna as informações do funcionário com o {id} informado.
        /// </summary>
        /// <param name="Id">Id do funcionario</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await service.GetEmployee(id).ConfigureAwait(false);

            if (ModelState.IsValid && employee != null)
            {
                return employee;
            }
            else
            {
                var objectReturn = new ObjectResult(404);
                ErrorReturn result = new ErrorReturn();
                List<EmployeeError> listError = new List<EmployeeError>();
                EmployeeError error = new EmployeeError();
                error.error = "Nao foi encontrado funcionario com o ID informado.";
                listError.Add(error);

                result.title = "One or more validation errors occurred.";
                result.status = 404;
                result.errors = listError;

                var jsonString = JsonSerializer.Serialize(result);
                objectReturn.Value = jsonString;
                return objectReturn;
            }
        }

        // POST: api/employees
        /// <summary>
        /// Permite inserir funcionário no banco de dados.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/employees
        ///     {        
        ///        "eName": "Primeiro nome",
        ///        "LastName": "Sobrenome",
        ///        "Doc": "62513589556",
        ///        "Sector": "Setor",
        ///        "Salary": 2000.00,
        ///        "DtAdmission": "2020-11-03",
        ///        "HealthPlan": true,
        ///        "DentalPlan": true,
        ///        "Transport": true        
        ///     }
        /// </remarks>
        /// <param name="employee"></param>     
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (await service.EmployeeExists(employee.Doc).ConfigureAwait(false))
            {
                var objectReturn = new ObjectResult(409);
                ErrorReturn result = new ErrorReturn();
                List<EmployeeError> listError = new List<EmployeeError>();
                EmployeeError error = new EmployeeError();
                error.error = "Ja existe funcionario com o CPF informado.";
                listError.Add(error);

                result.title = "One or more validation errors occurred.";
                result.status = 409;
                result.errors = listError;

                var jsonString = JsonSerializer.Serialize(result);
                objectReturn.Value = jsonString;
                return objectReturn;
            }

            if (ModelState.IsValid)
            {
                service.PostEmployee(employee);
                await service.Save();
            }

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // GET: api/employees/{id}
        /// <summary>
        /// Retorna o extrato salarial do funcionário com o {id} informado.
        /// </summary>
        /// <param name="Id">Id do funcionario</param>
        [HttpGet("paycheck/{id}")]
        public async Task<ActionResult<Paycheck>> PayCheck(int id)
        {
            Employee employee = await service.GetEmployee(id).ConfigureAwait(false);
            var paycheck = new PaycheckController();

            if (employee == null || !ModelState.IsValid)
            {
                var objectReturn = new ObjectResult(404);
                ErrorReturn result = new ErrorReturn();
                List<EmployeeError> listError = new List<EmployeeError>();
                EmployeeError error = new EmployeeError();
                error.error = "Nao foi encontrado funcionario com o ID informado.";
                listError.Add(error);

                result.title = "One or more validation errors occurred.";
                result.status = 404;
                result.errors = listError;

                var jsonString = JsonSerializer.Serialize(result);
                objectReturn.Value = jsonString;
                return objectReturn;
            }
            else
            {
                return paycheck.PaycheckGet(employee);
            }
        }


    }
}
