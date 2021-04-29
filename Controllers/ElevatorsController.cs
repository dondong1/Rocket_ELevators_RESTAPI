using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Rocket_Elevators_REST_API.Models;

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

        [HttpGet("get/status/inactive")]
        public IEnumerable<Elevators> GetElevatorsInactive()
        {
            IQueryable<Elevators> Elevators =
                from elev in _context.Elevators
                where elev.Status == "Inactive" select elev;
            return Elevators.ToList();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Elevators>>
        Patch(int id, [FromBody] JsonPatchDocument<Elevators> info)
        {
            var elevator = await _context.Elevators.FindAsync(id);

            info.ApplyTo (elevator);
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
        public async Task<ActionResult<IEnumerable<Elevators>>>
        GetelevatorsStatus()
        {
            return await _context
                .Elevators
                .Where(Elevator => Elevator.Status != "Online")
                .ToListAsync();
        }

        [HttpPut("{id}")]
        public IActionResult PutElevatorStatus(long id, Elevators item)
        {
            var ele = _context.Elevators.Find(id);
            if (ele == null)
            {
                return NotFound();
            }
            ele.Status = item.Status;

            _context.Elevators.Update (ele);
            _context.SaveChanges();

            var jsonPut = new JObject();
            jsonPut["Update"] =
                "Update done to elevator id : " +
                id +
                " to the status : " +
                ele.Status;
            return Content(jsonPut.ToString(), "application/json");
        }

        [HttpPost]
        public async Task<ActionResult<Elevators>>
        PostElevator(Elevators elevator)
        {
            _context.Elevators.Add (elevator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElevator",
            new { id = elevator.Id },
            elevator);
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

            _context.Elevators.Remove (elevator);
            await _context.SaveChangesAsync();

            return elevator;
        }

        private bool ElevatorExists(int id)
        {
            return _context.Elevators.Any(e => e.Id == id);
        }

        [HttpGet("columnId/{columnId}")]
        public async Task<ActionResult<IEnumerable<Elevators>>>
        GetelevatorByColumnId(long columnId)
        {
            var elevators =
                await _context
                    .Elevators
                    .Where(c => c.ColumnId == columnId)
                    .ToListAsync();

            if (elevators == null)
            {
                return NotFound();
            }

            return elevators;
        }
    }
}
