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
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _iroleRepository;
        public RoleService(IRoleRepository iroleRepository)
        {
            _iroleRepository = iroleRepository;
        }
        public async Task<IEnumerable<Role>> GetListAsync()
        {
            return await _iroleRepository.GetListAsync();
        }
        
        public async Task<Role> AddAsync(Role role)
        {
            return await _iroleRepository.AddAsync(role);
        }
    }
}
