using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solid.API.Models;
using Solid.core;
using Solid.core.DTOs;
using Solid.core.Enentities;
using Solid.core.Repositories;
using Solid.core.Services;
using Solid.service.Repository;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRoleService _iroleService;
        private readonly IMapper _mapper;
        public RolesController(IRoleService iroleService, IMapper mapper)
        {
            _iroleService = iroleService;
            _mapper = mapper;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var customers = await _iroleService.GetListAsync();
            return Ok(_mapper.Map<IEnumerable<Role>>(customers));
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] RolePostModel role)
        {
            var newRole = await _iroleService.AddAsync(_mapper.Map<Role>(role));
            return Ok(_mapper.Map<RoleDto>(newRole));
        }
    }
}