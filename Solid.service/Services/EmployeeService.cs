using Solid.core.Enentities;
using Solid.core.Repositories;
using Solid.core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.service.Repository
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _iemployeeRepository;
        public EmployeeService(IEmployeeRepository iemployeeRepository)
        {
            _iemployeeRepository = iemployeeRepository;
        }
        public async Task<IEnumerable<Employee>> GetListAsync()
        {
            return await _iemployeeRepository.GetListAsync();
        }
        public async Task<Employee> GetByIdAsync(long id)
        {
            return await _iemployeeRepository.GetByIdAsync(id);
        }
        public async Task<Employee> AddAsync(Employee employee)
        {
            return await _iemployeeRepository.AddAsync(employee);
        }
        public async Task<Employee> UpdateAsync(Employee employee, long id)
        {
            return await _iemployeeRepository.UpdateAsync(employee, id);
        }
        
        public async Task<Employee> DeleteAsync(long id)
        {
            return await _iemployeeRepository.DeleteAsync(id);
        }
    }
}
