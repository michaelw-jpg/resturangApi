using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Dto.TablesDtos;
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
    public class TablesController(IGenericRepository repo, IGenericItemService service, ITableService tableService) : ControllerBase
    {
        private readonly IGenericRepository _repo = repo;
        private readonly IGenericItemService _service = service;
        private readonly ITableService _tableService = tableService;

        // GET: api/Tables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            var tables = await _repo.GetAll<Table>();
            return Ok(tables);
        }

        [HttpGet("availabletables")]
        public async Task<ActionResult<IEnumerable<Table>>> GetAvailableTables(DateTime date, int guests)
        {
            var tables = await _tableService.GetAllAvailableTables(date, guests);
            
            return Ok(tables);
        }

        
        [HttpGet("availabletablebyid")]
        public async Task<ActionResult<Table>> GetAvailableTableById(DateTime date, int guests, int tableId)
        {
            var table = await _tableService.GetAvailableTableById(date, guests, tableId);
            if (table == null)
            {
                return NotFound("Table is not available");
            }
            return Ok(table);
        }

        // GET: api/Tables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _repo.GetItemByID<Table>(id);

            if (table == null)
            {
                return NotFound();
            }

            return table;
        }

        // PUT: api/Tables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTable(int id, [FromBody]PatchTableDto Dto)
        {
            var result = await _service.UpdateItem<Table, PatchTableDto>(id, Dto);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Tables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Table>> PostTable(CreateTableDto table)
        {
            var result = await _service.CreateItem<Table, CreateTableDto>(table);

            return CreatedAtAction("GetTable", new { id = result.TableId }, table);
        }

        // DELETE: api/Tables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
           var result = await _service.DeleteItem<Table>(id);
              if (!result)
            {
                return NotFound();
            }

            return Ok("Item Removed");
        }

      
    }
}
