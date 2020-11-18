using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkStatus.Contract.Request;
using NetworkStatus.Contract.Response;
using NetworkStatus.Persistence.Models;
using NetworkStatus.WebApi.Services;

namespace NetworkStatus.WebApi.Controllers
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
        [HttpPut("{nodeName}")]
        public async Task<IActionResult> PutNodeStatus(string nodeName, NodeStatusDto nodeStatus)
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;

            nodeStatus.Network.PrivateIpAddress = remoteIpAddress.MapToIPv4().ToString();

            await _nodeStatusService.UpsertNodeStatus(nodeStatus);
            
            return new OkResult();
        }

        // POST: api/NodeStatus
        [HttpPost]
        public async Task<ActionResult<NodeStatus>> PostNodeStatus(NodeStatusDto nodeStatus)
        {
            await _nodeStatusService.AddNodeStatus(nodeStatus);

            return CreatedAtAction("GetNodeStatus", new { id = nodeStatus.Id }, nodeStatus);
        }

        private bool NodeStatusExists(string nodeName)
        {
            return _nodeStatusService.Exists(nodeName);
        }
    }
}
