using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;


namespace Rocket_Elevator_RESTApi.Controllers
{
    [Route("api/Interventions")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;

        public InterventionsController(RailsApp_developmentContext context)
        {
            _context = context;
        }
        // ******* This GET returns all fields of all Interventions records that do not have a start date and are in "Pending" status. *******
        // GET: api/Interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetIntervention()
        {            
            var queryInterventions = from intervention in _context.Interventions
                                        where intervention.StartDateIntervention == null && intervention.Status == "Pending"
                                        select intervention;

            return await queryInterventions.ToListAsync();        
        }

        // ******* This PUT change the status of the intervention request to "InProgress" and add a start date and time (Timestamp). *******
        // PUT: api/Interventions/5/start-progress
        [HttpPut("{id}/start-progress")]
        public async Task<ActionResult<Interventions>> PutInterventionStart(int id)
        {
           var existingIntervention = await _context.Interventions.Where(i => i.Id == id)
                                                    .FirstOrDefaultAsync<Interventions>();

            if(existingIntervention == null)
            {
                return NotFound();
            }

            existingIntervention.StartDateIntervention = DateTime.Now;
            existingIntervention.UpdatedAt = DateTime.Now;
            existingIntervention.Status = "InProgress";

            _context.SaveChanges();

            return existingIntervention;
        }
        
        // ******* This PUT change the status of the request for action to "Completed" and add an end date and time (Timestamp). *******
        // PUT: api/Interventions/1/complete-progress
        [HttpPut("{id}/complete-progress")]
        public async Task<ActionResult<Interventions>> PutInterventionEnd(int id)
        {
           var existingIntervention = await _context.Interventions.Where(i => i.Id == id)
                                                    .FirstOrDefaultAsync<Interventions>();

            if(existingIntervention == null)
            {
                return NotFound();
            }

            existingIntervention.EndDateIntervention = DateTime.Now;
            existingIntervention.UpdatedAt = DateTime.Now;
            existingIntervention.Status = "Completed";

            _context.SaveChanges();

            return existingIntervention;
        }

        

        // ========== Post to save a new intervention ========================================================================
        // POST: api/Interventions
        [HttpPost]
        public async Task<ActionResult<Interventions>> PostIntervention(Interventions newIntervention)
        {
            newIntervention.StartDateIntervention = DateTime.Now;
            newIntervention.UpdatedAt = DateTime.Now;
            newIntervention.Status = "InProgress";
            newIntervention.Result = "Incomplete";
            newIntervention.EmployeeId = null;

            _context.Interventions.Add(newIntervention);
            await _context.SaveChangesAsync();

            return newIntervention;
        }
        
        


        
        
        // [Route("api/Interventions/Pending")]
        



        // // GET: api/Interventions/Pending
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        // {   
        //     // Create a list of interventions where the status is "Pending" and the StartDateIntervention is null
        //     var listInterventions =    from inter in _context.Interventions
        //                                 where inter.StartDateIntervention == null &&
        //                                 inter.Status == "Pending"
        //                                 select inter;

        //     // Return the list to the client in json format
        //     return await listInterventions.ToListAsync();
        // }

        // [Route("api/Interventions/Start/{id}")]
        // [HttpPut("{id}")]
        // public async Task<ActionResult<Interventions>> InterventionStarted(int id)
        // {
        //     // Create a instance of Intervention getting the data of the database with the id give in the query
        //     var intervention = await _context.Interventions.FindAsync(id);

        //     // Check if the intervention exists
        //     if (id != intervention.Id)
        //     {
        //         return BadRequest();
        //     }
            
        //     // Change the attribut to datetime a the query and the status to "InProgress"
        //     intervention.StartDateIntervention = DateTime.Now;
        //     intervention.Status = "InProgress";
            
        //     // Push modifications to the database
        //     await _context.SaveChangesAsync();

        //     // Return the new object internvention with the modifications to the client
        //     return intervention;
        // }

        // [Route("api/Interventions/End/{id}")]
        // [HttpPut("{id}")]

        // public async Task<ActionResult<Interventions>> InterventionFinish(int id)
        // {
        //     // Create a instance of Intervention getting the data of the database with the id give in the query
        //     var intervention = await _context.Interventions.FindAsync(id);
            
        //     // Check if the intervention exists
        //     if (id != intervention.Id)
        //     {
        //         return BadRequest();
        //     }

        //     // Change the end_date_intervention attribut to datetime a the query and the status to "Complete"
        //     intervention.EndDateIntervention = DateTime.Now;
        //     intervention.Status = "Complete";

        //     // Push modifications to the database
        //     await _context.SaveChangesAsync();
            
        //     // Return the new object internvention with the modifications to the client
        //     return intervention;
        // }
    }
}
