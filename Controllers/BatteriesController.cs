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
  [Route("api/Batteries")]
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
//
//
// GET: api/Batteries
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Batteries>>> Getbatteries()
        // {
        //     return await _context.Batteries.ToListAsync();
        
        // }
         ////PATCH METHOD, where you change the status 
        
        [HttpPatch("{id}")]
        public async Task<ActionResult<Batteries>> Patch(int id, [FromBody]JsonPatchDocument<Batteries> info)
        {
            
            var battery = await _context.Batteries.FindAsync(id);

            info.ApplyTo(battery);
            await _context.SaveChangesAsync();

            return battery;
        }

        // GET: api/Batteries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Batteries>> GetBattery(int id)
        {
            var battery = await _context.Batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery;
        }

        // PUT: api/Batteries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattery(int id, Batteries battery)
        {
            if (id != battery.Id)
            {
                return BadRequest();
            }

            _context.Entry(battery).State = EntityState.Modified;

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

        [HttpPost]
        public async Task<ActionResult<Batteries>> PostBattery(Batteries battery)
        {
            _context.Batteries.Add(battery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBattery", new { id = battery.Id }, battery);
        }

        // DELETE: api/Batteries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Batteries>> DeleteBattery(int id)
        {
            var battery = await _context.Batteries.FindAsync(id);
            if (battery == null)
            {
                return NotFound();
            }

            _context.Batteries.Remove(battery);
            await _context.SaveChangesAsync();

            return battery;
        }

        private bool BatteryExists(int id)
        {
            return _context.Batteries.Any(e => e.Id == id);
        }

        [HttpGet("buildingId/{buildingId}")]
        public async Task<ActionResult<IEnumerable<Batteries>>> GetbatteriesBybuildingId(long buildingId)
        {
            var batteries = await _context.Batteries.Where(c => c.BuildingId == buildingId).ToListAsync();

            if (batteries == null)
            {
                return NotFound();
            }

            return batteries;
        }
    // [HttpGet("{id}/status")]
    // public async Task<ActionResult<string>> GetBatteryStatus(long id)
    // {
    //   var battery = await _context.Batteries.FindAsync(id);

    //   if (battery == null)
    //   {
    //     return NotFound();
    //   }

    //   return battery.Status;
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> ChangeBatteryStatus(long id, [FromBody] Batteries battery)
    // {
    //   var findBattery = await _context.Batteries.FindAsync(id);

    //   if (battery == null)
    //   {
    //     return BadRequest();
    //   }

    //   if (findBattery == null)
    //   {
    //     return NotFound();
    //   }

    //   if (battery.Status == findBattery.Status)
    //   {
    //     ModelState.AddModelError("Status", "Looks like you didn't change the status.");
    //   }

    //   if (!ModelState.IsValid)
    //   {
    //     return BadRequest(ModelState);
    //   }

    //   findBattery.Status = battery.Status;

    //   try
    //   {
    //     await _context.SaveChangesAsync();
    //   }
    //   catch (DbUpdateConcurrencyException)
    //   {
    //     if (!BatteryExists(id))
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

    // private bool BatteryExists(long id)
    // {
    //   return _context.Batteries.Any(e => e.Id == id);
    // }


    
  }
}