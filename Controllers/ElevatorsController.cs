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
  [Route("api/Elevators")]
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

        // GET: api/Elevators
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Elevators>>> Getelevators()
//         {
           
//  //////This return all commercial elevators where date of last inspection is over a year
//             DateTime current =  DateTime.Now.AddMonths(-12);

//             var queryElevators = from elev in _context.Elevators
//                                  where elev.BuildingType == "Commercial" || elev.DateOfLastInspection < current
//                                  select elev;

//             var distinctElevators = (from elev in queryElevators
//                                     select elev).Distinct();


//             return await distinctElevators.ToListAsync();
//         }

        
        [HttpPatch("{id}")]
        public async Task<ActionResult<Elevators>> Patch(int id, [FromBody]JsonPatchDocument<Elevators> info)
        {
            
            var elevator = await _context.Elevators.FindAsync(id);

            info.ApplyTo(elevator);
            await _context.SaveChangesAsync();

            return elevator;
        }

        // GET: api/Elevators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevators>> GetElevator(int id)
        {
            var elevator = await _context.Elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevators>>> GetelevatorsStatus()
        {
            return  await _context.Elevators
                    .Where(Elevator => Elevator.Status != "Online" ).ToListAsync();
            
        }

        // PUT: api/Elevators/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElevator(int id, Elevators elevator)
        {
            if (id != elevator.Id)
            {
                return BadRequest();
            }

            _context.Entry(elevator).State = EntityState.Modified;

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

        // POST: api/Elevators
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Elevators>> PostElevator(Elevators elevator)
        {
            _context.Elevators.Add(elevator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElevator", new { id = elevator.Id }, elevator);
        }

        // DELETE: api/Elevators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Elevators>> DeleteElevator(int id)
        {
            var elevator = await _context.Elevators.FindAsync(id);
            if (elevator == null)
            {
                return NotFound();
            }

            _context.Elevators.Remove(elevator);
            await _context.SaveChangesAsync();

            return elevator;
        }

        private bool ElevatorExists(int id)
        {
            return _context.Elevators.Any(e => e.Id == id);
        }

        [HttpGet("columnId/{columnId}")]
        public async Task<ActionResult<IEnumerable<Elevators>>> GetelevatorByColumnId(long columnId)
        {
            var elevators = await _context.Elevators.Where(c => c.CustomerId == CustomerId).ToListAsync();

            if (elevators == null)
            {
                return NotFound();
            }

            return elevators;
        }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<Elevators>> GetElevator(long id)
    // {
    //   var elevator = await _context.Elevators.FindAsync(id);

    //   if (elevator == null)
    //   {
    //     return NotFound();
    //   }

    //   return elevator;
    // }

    // [HttpGet("{id}/status")]
    // public async Task<ActionResult<string>> GetElevatorStatus(long id)
    // {
    //   var elevator = await _context.Elevators.FindAsync(id);

    //   if (elevator == null)
    //   {
    //     return NotFound();
    //   }

    //   return elevator.Status;
    // }

    // [HttpGet("inactive")]
    // public async Task<ActionResult<List<Elevators>>> InactiveElevators()
    // {
    //   var elevators = await _context.Elevators
    //       .Where(elevator => elevator.Status != "Active")
    //       .ToListAsync();

    //   return elevators;
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> ChangeElevatorStatus(long id, [FromBody] Elevators elevator)
    // {
    //   var findElevator = await _context.Elevators.FindAsync(id);

    //   if (elevator == null)
    //   {
    //     return BadRequest();
    //   }

    //   if (findElevator == null)
    //   {
    //     return NotFound();
    //   }

    //   if (elevator.Status == findElevator.Status)
    //   {
    //     ModelState.AddModelError("Status", "Looks like you didn't change the status.");
    //   }

    //   if (!ModelState.IsValid)
    //   {
    //     return BadRequest(ModelState);
    //   }

    //   findElevator.Status = elevator.Status;

    //   try
    //   {
    //     await _context.SaveChangesAsync();
    //   }
    //   catch (DbUpdateConcurrencyException)
    //   {
    //     if (!ElevatorExists(id))
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

    // private bool ElevatorExists(long id)
    // {
    //   return _context.Elevators.Any(e => e.Id == id);
    // }
  }
}