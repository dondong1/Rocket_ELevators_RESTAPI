using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;
using Newtonsoft.Json.Linq;

namespace Rocket_Elevator_RESTApi.Controllers
{

    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;  

        public EmployeesController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        
        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()

        {
            return await _context.Employees.ToListAsync();
        }

        // ========== Get all the infos about a customer (buildings, batteries, columns, elevators) using the customer_id ==========
        // GET: api/Employees/cindy@client.com
        [HttpGet("{email}")]
         public async Task<ActionResult<List<Employees>>> GetEmployeebys(string Email)
        {
            var employee = await _context.Employees.Where(c => c.Email == Email).ToListAsync();

            if (Employees == null)
            {
                return BadRequest();
            }

            return employee;
        }

        // ========== Verify email for register at the Customer's Portal =========================================================================
        // GET: api/Customers/verify/cindy@client.com
        [HttpGet("verify/{email}")]
        public async Task<ActionResult> VerifyEmail(string email)
        {
            var employee = await _context.Employees.Include("Buildings.Batteries.Columns.Elevators")
                                                .Where(c => c.Email == email)
                                                .FirstOrDefaultAsync();            

            if (email == null)
            {
                return NotFound();
            }

            return Ok();
        } 

       
    }
}