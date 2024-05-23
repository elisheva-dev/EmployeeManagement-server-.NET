using Solid.core.Enentities;

namespace Solid.API.Models
{
    public class EmployeeRolesPostModel
    {
        public int RoleId { get; set; }
        public bool IsManagerial { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
