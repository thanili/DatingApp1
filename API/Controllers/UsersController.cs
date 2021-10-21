using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(
            IUserRepository userRepository,
            IMapper mapper    
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //[AllowAnonymous]
        // api/users endpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            //var users = await _userRepository.GetUsersAsync();
            //var usersToReturn = _mapper.Map< IEnumerable<MemberDto>>(users);
            //return Ok(usersToReturn);
            var members = await _userRepository.GetMembersAsync();
            return Ok(members);
        }

        //[Authorize]
        // api/users/x endpoint
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            //var user = await _userRepository.GetUserByUsername(username);
            //var userToReturn = _mapper.Map<MemberDto>(user);
            //return userToReturn;
            return await _userRepository.GetMemberAsync(username);            
        }
    }
}
