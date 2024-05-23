using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.core.Enentities
{
    public class EmployeeRoles
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public bool IsManagerial { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
