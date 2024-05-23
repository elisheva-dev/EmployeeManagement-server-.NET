using Solid.core.Enentities;
using System.Reflection;

namespace Solid.API.Models
{
    public class EmployeePostModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BeginningWork { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public List<EmployeeRolesPostModel> Roles { get; set; }
    }
}
