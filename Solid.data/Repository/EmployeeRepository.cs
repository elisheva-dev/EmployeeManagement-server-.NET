using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore;
using Solid.core.Enentities;
using Solid.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetListAsync()
        {
            return await _context.Employees.Include(e => e.Roles)
                .Where(e => e.IsActive) 
                .ToListAsync();
        }
        public async Task<Employee> GetByIdAsync(long id)
        {
            var e = await _context.Employees.Include(e => e.Roles)
                                            .FirstOrDefaultAsync(emp => emp.Id == id && emp.IsActive);
            return e;
        }
        public async Task<Employee> AddAsync(Employee employee)
        {
            var existingEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (existingEmployee is null)
            {
                var duplicateRoles = employee.Roles.GroupBy(r => r.RoleId)
                                                   .Where(g => g.Count() > 1).Select(g => g.Key).ToList();
                if (duplicateRoles.Any())
                    throw new Exception("אין להכניס תפקיד יותר מפעם אחת לרשימת התפקידים");
                // בדיקה האם יש תפקיד שמתחיל לפני תחילת העבודה
                var invalidRoles = employee.Roles.Where(r => r.EntryDate < employee.BeginningWork).ToList();
                if (invalidRoles.Any())
                    throw new Exception("יש תפקידים שמתחילים לפני תחילת העבודה של העובד");
                employee.IsActive = true;
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            else
            {
                if (existingEmployee.IsActive)
                {
                    throw new Exception("משתמש קיים במערכת");
                }
                else
                {
                    var invalidRoles = employee.Roles.Where(r => r.EntryDate < employee.BeginningWork).ToList();
                    if (invalidRoles.Any())
                        throw new Exception("יש תפקידים שמתחילים לפני תחילת העבודה של העובד");

                    existingEmployee.IsActive = true;
                    existingEmployee.FirstName = employee.FirstName;
                    existingEmployee.LastName = employee.LastName;
                    existingEmployee.DateOfBirth = employee.DateOfBirth;
                    existingEmployee.BeginningWork = employee.BeginningWork;
                    existingEmployee.Gender = employee.Gender;
                    if (existingEmployee.Roles is null)
                    {
                        existingEmployee.Roles = new List<EmployeeRoles>();
                    }
                    else
                    {
                        existingEmployee.Roles.Clear();
                    }
                    await _context.SaveChangesAsync();
                }
            }
            return null;
        }
        public async Task<Employee> UpdateAsync(Employee employee, long id)
        {
            var e = await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
            if (e != null)
            {
                e.FirstName = employee.FirstName;
                e.LastName = employee.LastName;
                e.DateOfBirth = employee.DateOfBirth;
                e.BeginningWork = employee.BeginningWork;
                e.Gender = employee.Gender;
                await _context.SaveChangesAsync();
                return e;
            }
            return null; 
        }
       
        public async Task<Employee> DeleteAsync(long id)
        {
            var e = _context.Employees.FirstOrDefault(emp => emp.Id == id);
            e.IsActive = false;
            await _context.SaveChangesAsync();
            return e;
        }
    }
}
