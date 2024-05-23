using Solid.core.Enentities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.core.DTOs
{
    public class EmployeeRolesDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public bool IsManagerial { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
