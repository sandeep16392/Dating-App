using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DatingApp.DAL.Interface;
using DatingApp.Model.DataModels;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDm userForUpdate)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repository.GetUser(id);
            var userToSave = _mapper.MapDmToEm(userForUpdate, userFromRepo);

            if (await _repository.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save.");
        }

    }
}