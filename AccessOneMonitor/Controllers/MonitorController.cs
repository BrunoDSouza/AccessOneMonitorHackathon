using AccessOneMonitor.Services;
using System;
using System.Web.Http;

namespace AccessOneMonitor.Controllers
{
    [RoutePrefix("api/monitor")]
    public class MonitorController : ApiController
    {
        private readonly IMonitorService _monitorService;

        public MonitorController(IMonitorService monitorService)
        {
            _monitorService = monitorService;
        }

        [Route("ExecutionCommand")]
        [HttpPost]
        public IHttpActionResult ExecutionCommand([FromBody] int commandId, [FromBody] long[] computers)
        {
            try
            {
                var commands = _monitorService.ExecuteCommand(commandId, computers);
                return Ok(commands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllCommands")]
        [HttpGet]
        public IHttpActionResult GetAllCommands()
        {
            try
            {
                var commands = _monitorService.GetAllCommands();
                return Ok(commands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllComputers")]
        [HttpGet]
        public IHttpActionResult GetAllComputers()
        {
            try
            {
                var commands = _monitorService.GetAllComputers();
                return Ok(commands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
