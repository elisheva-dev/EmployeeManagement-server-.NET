using Microsoft.VisualBasic;
using Solid.core.DTOs;
using Solid.core.Enentities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.core
{
    public class Mapping
    {
        public RoleDto MapToRoleDto(Role role)
        {
            return new RoleDto { Id=role.Id, Title=role.Title };
        }
        public EmployeeRolesDto MapToEmployeeRolesDto(EmployeeRoles employeeRoles)
        {
            return new EmployeeRolesDto { Id = employeeRoles.Id, RoleId = employeeRoles.RoleId, EntryDate = employeeRoles.EntryDate, IsManagerial = employeeRoles.IsManagerial };
        }
        public EmployeeDto MapToEmployeeDto(Employee employee)
        {
            return new EmployeeDto {Id= employee.Id, FirstName= employee.FirstName,LastName= employee.LastName, BeginningWork= employee.BeginningWork };
        }
    }
}
