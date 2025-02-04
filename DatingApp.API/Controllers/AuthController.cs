﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Configs;
using DatingApp.DAL.Interface;
using DatingApp.Model.DataModels;
using DatingApp.Model.EntityModels;
using DatingApp.Model.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly ICommonConfigurations _config;
        private readonly IMapper _mapper;
        private readonly IUserMapper _userMapper;

        public AuthController(IAuthRepository authRepository, ICommonConfigurations config, IMapper mapper, IUserMapper userMapper)
        {
            _authRepository = authRepository;
            _config = config;
            _mapper = mapper;
            _userMapper = userMapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDm user)
        {
            //validate request

            user.Username = user.Username.ToLower();

            if (await _authRepository.UserExists(user.Username))
                return BadRequest("Username already exists.");

            var userToCreate = _mapper.Map<User>(user);

            await _authRepository.Register(userToCreate, user.Password);

            var userToReturn = _userMapper.MapEmToDm(userToCreate);

            return CreatedAtRoute("GetUser", new{controller = "Users", id= userToReturn.Id}, userToReturn);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDm loginUser)
        {
            var userFromRepo = await _authRepository.Login(loginUser.Username.ToLower(), loginUser.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName.ToLower())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Token));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var userToReturn = _mapper.Map<UserListDm>(userFromRepo);
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user = userToReturn
            });
        }
    }
}