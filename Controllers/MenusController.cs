using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Dto.MenuDtos;
using resturangApi.Models;
using resturangApi.Repositories.Interface;
using resturangApi.Services.Iservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturangApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class menusController : ControllerBase
    {
        private readonly IGenericRepository _repo;
        private readonly IGenericItemService _GenericService;

        public menusController(IGenericRepository repo, IGenericItemService _genericService)
        {
            _repo = repo;
            _GenericService = _genericService;
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
            
            var result = await _GenericService.UpdateItem<Menu,PatchMenuDto>(id, request);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
           
        }

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(CreateMenuDto menu)
        {
            var result = await _GenericService.CreateItem<Menu, CreateMenuDto>(menu);
            if (result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetMenu", new { id = result.MenuId }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
           var result = await _GenericService.DeleteItem<Menu>(id);

            if (!result)
            {
                return NotFound();
            }
            return Ok("Item Removed");
        }

    }
}
