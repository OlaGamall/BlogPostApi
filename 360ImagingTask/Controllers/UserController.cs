using _360ImagingTask.Models;
using _360ImagingTask.Services;
using _360ImagingTask.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace _360ImagingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IBlogRepo _repo;
        readonly IMapper _mapper;

        public UserController(IBlogRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _repo.GetUserById(id);

            if (user == null)
                return NotFound();
           

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_repo.GetUsers());
        }

        [HttpPost]
        public IActionResult AddUser(UserDto user)
        {
            var mappedUser = _mapper.Map<User>(user);

            _repo.Add(mappedUser);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult EditUser(int id, UserDto user)
        {
            var u = _repo.GetUserById(id);
            if (u == null)
                return BadRequest();

            u.UserName = user.UserName;

            _repo.Update(u);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var u = _repo.GetUserById(id);
            if (u == null)
                return NotFound();

            _repo.Delete(u);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}
