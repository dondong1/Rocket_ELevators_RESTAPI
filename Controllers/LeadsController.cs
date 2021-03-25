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
  public class LeadsController : ControllerBase
  {
    private readonly RailsApp_developmentContext _context;

    public LeadsController(RailsApp_developmentContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Leads>>> GetLeads()
    {
      return await _context.Leads.ToListAsync();
    }

    [HttpGet("recent")]
    public async Task<ActionResult<List<Leads>>> LastThirtyDays()
    {
      var lead = await _context.Leads
        .Where(lead => lead.customer_id == null)
        .ToListAsync();

      var newLeads = lead.Where(lead => lead.CreatedAt <= DateTime.Today.AddDays(-30)).ToList();

      if (newLeads == null)
      {
        return NotFound();
      }

      return newLeads;
    }
    
  }
}