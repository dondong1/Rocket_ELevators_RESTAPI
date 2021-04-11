using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;

namespace Rocket_Elevator_RESTApi.Controllers
{

    [Route("api/Customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly RailsApp_developmentContext _context;  

        public CustomersController(RailsApp_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> Getcustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // ========== Get all the infos about a customer (buildings, batteries, columns, elevators) using the customer_id ==========
        // GET: api/Customers/cindy@client.com
        [HttpGet("{email}")]
         public async Task<ActionResult<List<Customers>>> GetCustomerbyEmail(string Email)
        {
            var customer = await _context.Customers.Where(c => c.EmailOfCompanyContact == Email).ToListAsync();

            if (!CustomerExists(Email))
            {
                return BadRequest();
            }

            return customer;
        }

        // ========== Verify email for register at the Customer's Portal =========================================================================
        // GET: api/Customers/verify/cindy@client.com
        [HttpGet("verify/{email}")]
        public async Task<ActionResult> VerifyEmail(string email)
        {
            var customer = await _context.Customers.Include("Buildings.Batteries.Columns.Elevators")
                                                .Where(c => c.EmailOfCompanyContact == email)
                                                .FirstOrDefaultAsync();            

            if (customer == null)
            {
                return NotFound();
            }

            return Ok();
        } 

        // ========== Put for update the customer infos =========================================================================
        // PUT: api/Customers/cindy@client.com
        [HttpPut]
        public async Task<ActionResult<Customers>> PutCustomer(Customers customer)
        {
            var customerToUpdate = await _context.Customers
                                                .Where(c => c.EmailOfCompanyContact == customer.EmailOfCompanyContact)
                                                .FirstOrDefaultAsync(); 

            if (customerToUpdate == null)
            {
                return NotFound();
            }

            customerToUpdate.CompanyName = customer.CompanyName;
            customerToUpdate.FullNameOfCompanyContact = customer.FullNameOfCompanyContact;
            customerToUpdate.CompanyContactPhone = customer.CompanyContactPhone;
            customerToUpdate.FullNameOfServiceTechnicalAuthority = customer.FullNameOfServiceTechnicalAuthority;
            customerToUpdate.TechnicalAuthorityPhoneForService = customer.TechnicalAuthorityPhoneForService;
            customerToUpdate.TechnicalManagerEmailForService = customer.TechnicalManagerEmailForService;
            customerToUpdate.CompanyDescription = customer.CompanyDescription;

            await _context.SaveChangesAsync();

            return customerToUpdate;
        }
         private bool CustomerExists(string email)
        {
            return _context.Customers.Any(e => e.EmailOfCompanyContact == email);
        }
    }
}