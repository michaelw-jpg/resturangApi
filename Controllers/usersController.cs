using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Dto.UserDtos;
using resturangApi.Models;
using resturangApi.Repositories.Interface;
using resturangApi.Services.Iservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturangApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IGenericRepository repo, IGenericItemService service) : ControllerBase
    {
        private readonly IGenericRepository _repo = repo;
        private readonly IGenericItemService _service = service;

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _repo.GetAll<User>();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Getuser(Guid id)
        {
            var user = await _repo.GetItemByID<User>(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUser(Guid id, PatchUserDto dto)
        {
            //need logic here to hash password if password is being updated
            var result = await _service.UpdateItem<User, PatchUserDto>(id, dto);
            
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> Postuser(CreateUserDto user)
        {
            //need logic here to hash password
            var result = await _service.CreateItem<User, CreateUserDto>(user);

            if (result == null)
            {
                return BadRequest("Could not create user");
            }
            //need to setup dto that does not return password hash
            return CreatedAtAction("Getuser", new { id = result.UserId }, user);
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuser(Guid id)
        {
            var result = await _service.DeleteItem<User>(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("User deleted");
        }

        
    }
}
