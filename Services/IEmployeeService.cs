using System;
using System.Threading.Tasks;

namespace webapi.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(int id);
        void PostEmployee(Employee employee);
        Task<Int32> Save();
        Task<bool> EmployeeExists(string cpf);
    }
}
