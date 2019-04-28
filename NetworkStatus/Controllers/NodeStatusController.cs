using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetworkStatus.Data;
using NetworkStatus.Dto;
using NetworkStatus.Dto.Response;
using NetworkStatus.Models;
using NetworkStatus.Services;
using Newtonsoft.Json;

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
        public async Task<ActionResult<IEnumerable<NodeStatusResponseDto>>> GetNodeStatus()
        {
            return new JsonResult(await _nodeStatusService.Index());
        }

        // GET: api/NodeStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NodeStatusResponseDto>> GetNodeStatus(int id)
        {
            var nodeStatus = await _nodeStatusService.Get(id);

            if (nodeStatus == null)
            {
                return NotFound();
            }

            return nodeStatus;
        }

        // PUT: api/NodeStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNodeStatus(int id, NodeStatusDto nodeStatus)
        {
            if (id != nodeStatus.Id)
            {
                return BadRequest();
            }

            if (!NodeStatusExists(id))
            {
                return NotFound();
            }

            await _nodeStatusService.UpdateNodeStatus(nodeStatus);
            
            return new OkResult();
        }

        // POST: api/NodeStatus
        [HttpPost]
        public async Task<ActionResult<NodeStatus>> PostNodeStatus(NodeStatusDto nodeStatus)
        {
            await _nodeStatusService.AddNodeStatus(nodeStatus);

            return CreatedAtAction("GetNodeStatus", new { id = nodeStatus.Id }, nodeStatus);
        }

        private bool NodeStatusExists(int id)
        {
            return _nodeStatusService.Exists(id);
        }
    }
}
