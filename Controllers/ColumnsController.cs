using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Rocket_Elevators_REST_API.Controllers
{
//   [Produces("application/json")]
  [Route("api/Columns")]
  [ApiController]
  public class ColumnsController : ControllerBase
  {
    private readonly RailsApp_developmentContext _context;

    public ColumnsController(RailsApp_developmentContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Columns>>> GetColumns()
    {
      return await _context.Columns.ToListAsync();
    }
// GET: api/Columns
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Columns>>> Getcolumns()
        // {
        //     return await _context.Columns.Include(b => b.Battery).ToListAsync();
        // }

        
        [HttpPatch("{id}")]
        public async Task<ActionResult<Columns>> Patch(int id, [FromBody]JsonPatchDocument<Columns> info)
        {
            
            var column = await _context.Columns.FindAsync(id);

            info.ApplyTo(column);
            await _context.SaveChangesAsync();

            return column;
        }

        // GET: api/Columns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Columns>> GetColumn(int id)
        {
            var column = await _context.Columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column;
        }

        // PUT: api/Columns/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColumn(int id, Columns column)
        {
            if (id != column.Id)
            {
                return BadRequest();
            }

            _context.Entry(column).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Columns
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Columns>> PostColumn(Columns column)
        {
            _context.Columns.Add(column);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColumn", new { id = column.Id }, column);
        }

        // DELETE: api/Columns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Columns>> DeleteColumn(int id)
        {
            var column = await _context.Columns.FindAsync(id);
            if (column == null)
            {
                return NotFound();
            }

            _context.Columns.Remove(column);
            await _context.SaveChangesAsync();

            return column;
        }

        private bool ColumnExists(int id)
        {
            return _context.Columns.Any(e => e.Id == id);
        }

        [HttpGet("batteriesId/{batteriesId}")]
        public async Task<ActionResult<IEnumerable<Columns>>> GetColumnBybatteriesId(long batteriesId)
        {
            var columns = await _context.Columns.Where(c => c.BatteryId == batteriesId).ToListAsync();

            if (columns == null)
            {
                return NotFound();
            }

            return columns;
        }


    // [HttpGet("{id}")]
    // public async Task<ActionResult<Columns>> GetColumn(long id)
    // {
    //   var column = await _context.Columns.FindAsync(id);

    //   if (column == null)
    //   {
    //     return NotFound();
    //   }

    //   return column;
    // }

    // [HttpGet("{id}/status")]
    // public async Task<ActionResult<string>> GetColumnStatus(long id)
    // {
    //   var column = await _context.Columns.FindAsync(id);

    //   if (column == null)
    //   {
    //     return NotFound();
    //   }

    //   return column.Status;
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> ChangeColumnStatus(long id, [FromBody] Columns column)
    // {
    //   var findColumn = await _context.Columns.FindAsync(id);

    //   if (column == null)
    //   {
    //     return BadRequest();
    //   }

    //   if (findColumn == null)
    //   {
    //     return NotFound();
    //   }

    //   if (column.Status == findColumn.Status)
    //   {
    //     ModelState.AddModelError("Status", "Looks like you didn't change the status.");
    //   }

    //   if (!ModelState.IsValid)
    //   {
    //     return BadRequest(ModelState);
    //   }

    //   findColumn.Status = column.Status;

    //   try
    //   {
    //     await _context.SaveChangesAsync();
    //   }
    //   catch (DbUpdateConcurrencyException)
    //   {
    //     if (!ColumnExists(id))
    //     {
    //       return NotFound();
    //     }
    //     else
    //     {
    //       throw;
    //     }
    //   }

    //   return NoContent();
    // }

    // private bool ColumnExists(long id)
    // {
    //   return _context.Columns.Any(e => e.Id == id);
    // }
  }
}