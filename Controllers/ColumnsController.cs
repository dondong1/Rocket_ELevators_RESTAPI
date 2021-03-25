using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;

namespace Rocket_Elevators_REST_API.Controllers
{
  [Route("[controller]")]
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

    [HttpGet("{id}")]
    public async Task<ActionResult<Columns>> GetColumn(long id)
    {
      var column = await _context.Columns.FindAsync(id);

      if (column == null)
      {
        return NotFound();
      }

      return column;
    }

    [HttpGet("{id}/status")]
    public async Task<ActionResult<string>> GetColumnStatus(long id)
    {
      var column = await _context.Columns.FindAsync(id);

      if (column == null)
      {
        return NotFound();
      }

      return column.Status;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ChangeColumnStatus(long id, [FromBody] Columns column)
    {
      var findColumn = await _context.Columns.FindAsync(id);

      if (column == null)
      {
        return BadRequest();
      }

      if (findColumn == null)
      {
        return NotFound();
      }

      if (column.Status == findColumn.Status)
      {
        ModelState.AddModelError("Status", "Looks like you didn't change the status.");
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      findColumn.Status = column.Status;

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

    private bool ColumnExists(long id)
    {
      return _context.Columns.Any(e => e.Id == id);
    }
  }
}