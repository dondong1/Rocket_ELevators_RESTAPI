using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocket_Elevators_REST_API.Models;
using Microsoft.EntityFrameworkCore;


namespace Rocket_Elevators_REST_API.Controllers
{
  [ApiController]
  [Route("api/Buildings")]
  public class BuildingsController : ControllerBase
  {
    private readonly RailsApp_developmentContext _context;

    public BuildingsController(RailsApp_developmentContext context)
    {
      _context = context;
    }


        // GET: api/Buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buildings>>> GetBuilding()
        {
                    ///THIS GET METHOD RETURN all buildings with status Intervention
            var queryBuildings = from build in _context.Buildings
                                 from bat in build.Batteries
                                 from col in bat.Columns
                                 from elv in col.Elevators
                                 where bat.Status == "Intervention" || col.Status == "Intervention" || elv.Status == "Intervention"
                                 select build;

            var distinctBuildings = (from build in queryBuildings
                                    select build).Distinct();


            return await distinctBuildings.ToListAsync();
        }

        // GET: api/Buildings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buildings>> GetBuilding(int id)
        {
            var building = await _context.Buildings.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }

            return building;
        }

        // PUT: api/Buildings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuilding(int id, Buildings building)
        {
            if (id != building.Id)
            {
                return BadRequest();
            }

            _context.Entry(building).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingExists(id))
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

        // POST: api/Buildings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Buildings>> PostBuilding(Buildings building)
        {
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuilding", new { id = building.Id }, building);
        }

        // DELETE: api/Buildings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Buildings>> DeleteBuilding(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();

            return building;
        }

        private bool BuildingExists(int id)
        {
            return _context.Buildings.Any(e => e.Id == id);
        }

    // // GET: api/Buildings
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Buildings>>> GetBuilding()
    // {

    //   var queryBuildings = from build in _context.Buildings
    //                        from bat in build.Batteries
    //                        from col in bat.Columns
    //                        from elv in col.Elevators
    //                        where bat.Status.Equals("Intervention") || col.Status.Equals("Intervention") || elv.Status.Equals("Intervention")
    //                        select build;

    //   var distinctBuildings = (from build in queryBuildings
    //                            select build).Distinct();


    //   return await distinctBuildings.ToListAsync();
    // }

    // private bool BuildingExists(int id)
    // {
    //   return _context.Buildings.Any(e => e.Id == id);
    // }
  }
}
