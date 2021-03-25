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
  public class BatteriesController : ControllerBase
  {
    private readonly RailsApp_developmentContext _context;
    
    public BatteriesController(RailsApp_developmentContext context)
    {
      _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Batteries>>> GetBatteries()
    {
      return await _context.Batteries.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Batteries>> GetBattery(long id)
    {
      var battery = await _context.Batteries.FindAsync(id);

      if (battery == null)
      {
        return NotFound();
      }

      return battery;
    }

    [HttpGet("{id}/status")]
    public async Task<ActionResult<string>> GetBatteryStatus(long id)
    {
      var battery = await _context.Batteries.FindAsync(id);

      if (battery == null)
      {
        return NotFound();
      }

      return battery.Status;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ChangeBatteryStatus(long id, [FromBody] Batteries battery)
    {
      var findBattery = await _context.Batteries.FindAsync(id);

      if (battery == null)
      {
        return BadRequest();
      }

      if (findBattery == null)
      {
        return NotFound();
      }

      if (battery.Status == findBattery.Status)
      {
        ModelState.AddModelError("Status", "Looks like you didn't change the status.");
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      findBattery.Status = battery.Status;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BatteryExists(id))
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

    private bool BatteryExists(long id)
    {
      return _context.Batteries.Any(e => e.Id == id);
    }
  }
}