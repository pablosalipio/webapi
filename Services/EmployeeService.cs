using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext context;

        public EmployeeService(EmployeeContext context)
        {
            this.context = context;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await context.Employees.FindAsync(id).ConfigureAwait(false);
        }

        public void PostEmployee(Employee employee)
        {
            context.Employees.Add(employee);
        }

        public async Task<Int32> Save()
        {
            return await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> EmployeeExists(string cpf)
        {
            return await context.Employees.AnyAsync(e => e.Doc == cpf);
        }

    }
}
