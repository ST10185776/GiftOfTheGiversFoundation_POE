using Microsoft.AspNetCore.Mvc;
using DisasterAlleviation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DisasterAlleviation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentReportController : ControllerBase
    {
        private readonly YourDbContext _context;

        public IncidentReportController(YourDbContext context)
        {
            _context = context;
        }

        // GET: api/incidentreport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentReport>>> GetIncidentReports()
        {
            return await _context.IncidentReports.ToListAsync();
        }

        // GET: api/incidentreport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentReport>> GetIncidentReport(int id)
        {
            var incidentReport = await _context.IncidentReports.FindAsync(id);

            if (incidentReport == null)
            {
                return NotFound();
            }

            return incidentReport;
        }

        // POST: api/incidentreport
        [HttpPost]
        public async Task<ActionResult<IncidentReport>> PostIncidentReport(IncidentReport incidentReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.IncidentReports.Add(incidentReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIncidentReport), new { id = incidentReport.incidentID }, incidentReport);
        }

        // PUT: api/incidentreport/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentReport(int id, IncidentReport incidentReport)
        {
            if (id != incidentReport.incidentID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(incidentReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentReportExists(id))
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

        // DELETE: api/incidentreport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidentReport(int id)
        {
            var incidentReport = await _context.IncidentReports.FindAsync(id);
            if (incidentReport == null)
            {
                return NotFound();
            }

            _context.IncidentReports.Remove(incidentReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidentReportExists(int id)
        {
            return _context.IncidentReports.Any(e => e.incidentID == id);
        }
    }
}
