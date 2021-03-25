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
  public class ElevatorsController : ControllerBase
  {
    private readonly RailsApp_developmentContext _context;

    public ElevatorsController(RailsApp_developmentContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Elevators>>> GetElevators()
    {
      return await _context.Elevators.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Elevators>> GetElevator(long id)
    {
      var elevator = await _context.Elevators.FindAsync(id);

      if (elevator == null)
      {
        return NotFound();
      }

      return elevator;
    }

    [HttpGet("{id}/status")]
    public async Task<ActionResult<string>> GetElevatorStatus(long id)
    {
      var elevator = await _context.Elevators.FindAsync(id);

      if (elevator == null)
      {
        return NotFound();
      }

      return elevator.Status;
    }

    [HttpGet("inactive")]
    public async Task<ActionResult<List<Elevators>>> InactiveElevators()
    {
      var elevators = await _context.Elevators
          .Where(elevator => elevator.Status != "Active")
          .ToListAsync();

      return elevators;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ChangeElevatorStatus(long id, [FromBody] Elevators elevator)
    {
      var findElevator = await _context.Elevators.FindAsync(id);

      if (elevator == null)
      {
        return BadRequest();
      }

      if (findElevator == null)
      {
        return NotFound();
      }

      if (elevator.Status == findElevator.Status)
      {
        ModelState.AddModelError("Status", "Looks like you didn't change the status.");
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      findElevator.Status = elevator.Status;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ElevatorExists(id))
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

    private bool ElevatorExists(long id)
    {
      return _context.Elevators.Any(e => e.Id == id);
    }
  }
}