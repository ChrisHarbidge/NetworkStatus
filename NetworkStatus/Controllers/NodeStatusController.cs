using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Data;
using NetworkStatus.Models;
using NetworkStatus.Services;

namespace NetworkStatus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeStatusController : ControllerBase
    {

        private readonly INodeStatusService _nodeStatusService;

        public NodeStatusController(INodeStatusService nodeStatusService)
        {
            _nodeStatusService = nodeStatusService;
        }

        // GET: api/NodeStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NodeStatus>>> GetNodeStatus()
        {
            return new JsonResult(await _nodeStatusService.Index());
        }

        // GET: api/NodeStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NodeStatus>> GetNodeStatus(int id)
        {
            var nodeStatus = await _context.NodeStatus
                .Include(node => node.Storage)
                .Include(node => node.Network)
                .Include(node => node.Services)
                .SingleOrDefaultAsync(node => node.Id == id);

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

            nodeStatus.LastPinged = DateTime.Now;

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

            return new OkResult();
        }

        // POST: api/NodeStatus
        [HttpPost]
        public async Task<ActionResult<NodeStatus>> PostNodeStatus(NodeStatus nodeStatus)
        {
            _context.NodeStatus.Add(nodeStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNodeStatus", new { id = nodeStatus.Id }, nodeStatus);
        }

        private bool NodeStatusExists(int id)
        {
            return _context.NodeStatus.Any(e => e.Id == id);
        }
    }
}
