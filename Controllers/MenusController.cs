using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Dto.MenuDtos;
using resturangApi.Models;
using resturangApi.Repositories.Interface;

namespace resturangApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IGenericRepository _repo;

        public MenusController(IGenericRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<List<Menu>>> GetMenus()
        {
            var menus = await _repo.GetAll<Menu>();
            return Ok(menus);
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _repo.GetItemByID<Menu>(id);
            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchMenu(int id, [FromBody]PatchMenuDto request)
        {
            
            var result = await _repo.UpdateItem<Menu,PatchMenuDto>(id, request);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
           
        }

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenu", new { id = menu.MenuId }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.MenuId == id);
        }
    }
}
