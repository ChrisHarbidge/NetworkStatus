using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Data;
using NetworkStatus.Models;

namespace NetworkStatus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NodeStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NodeStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NodeStatus>>> GetNodeStatus()
        {
            return await _context.NodeStatus.ToListAsync();
        }

        // GET: api/NodeStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NodeStatus>> GetNodeStatus(int id)
        {
            var nodeStatus = await _context.NodeStatus.FindAsync(id);

            if (nodeStatus == null)
            {
                return NotFound();
            }

            return nodeStatus;
        }

        // PUT: api/NodeStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNodeStatus(int id, NodeStatus nodeStatus)
        {
            if (id != nodeStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(nodeStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NodeStatusExists(id))
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

        // POST: api/NodeStatus
        [HttpPost]
        public async Task<ActionResult<NodeStatus>> PostNodeStatus(NodeStatus nodeStatus)
        {
            _context.NodeStatus.Add(nodeStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNodeStatus", new { id = nodeStatus.Id }, nodeStatus);
        }

        // DELETE: api/NodeStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NodeStatus>> DeleteNodeStatus(int id)
        {
            var nodeStatus = await _context.NodeStatus.FindAsync(id);
            if (nodeStatus == null)
            {
                return NotFound();
            }

            _context.NodeStatus.Remove(nodeStatus);
            await _context.SaveChangesAsync();

            return nodeStatus;
        }

        private bool NodeStatusExists(int id)
        {
            return _context.NodeStatus.Any(e => e.Id == id);
        }
    }
}
