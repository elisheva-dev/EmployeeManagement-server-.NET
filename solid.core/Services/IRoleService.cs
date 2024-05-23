using Solid.core.Enentities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.core.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetListAsync();
        Task<Role> AddAsync(Role role);
    }
}
