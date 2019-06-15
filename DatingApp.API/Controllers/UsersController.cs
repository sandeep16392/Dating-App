using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.DAL.Interface;
using DatingApp.Model.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repository;
        private readonly IUserMapper _mapper;

        public UsersController(IDatingRepository repository, IUserMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repository.GetUsers();
            var userDms = _mapper.MapEmsToDms(users);
            return Ok(userDms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repository.GetUser(id);
            var userDm = _mapper.MapEmToDm(user);
            return Ok(userDm);
        }
    }
}