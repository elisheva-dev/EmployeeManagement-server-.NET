using Solid.core.Enentities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetListAsync();
        Task<Employee> GetByIdAsync(long id);
        Task<Employee> AddAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee, long id);
        Task<Employee> DeleteAsync(long id);
    }
}
