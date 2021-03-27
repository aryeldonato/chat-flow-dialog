using Akka.Actor;
using ChatFlow.Dialog.Domain.Application;
using ChatFlow.Dialog.Domain.Dtos.BehaviorBot;
using ChatFlow.Dialog.Domain.Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChatFlow.Dialog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlowController : ControllerBase
    {
        private readonly ILogger<FlowController> _logger;
        private readonly ActorSystem _actorSystem;
        private readonly ChatFlowConfiguration _chatFlowConfiguration;

        public FlowController(ILogger<FlowController> logger, ActorSystem actorSystem, ChatFlowConfiguration chatFlowConfiguration)
        {
            _logger = logger;
            this._actorSystem = actorSystem;
            this._chatFlowConfiguration = chatFlowConfiguration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("i'm alive!");
        }

        [HttpPost]
        public IActionResult Post([FromBody]BBotMessage message)
        {
            var stateMachine = new StateMachine(_actorSystem);
            var ret = stateMachine.RunChain(message);

            return Ok(ret);
        }
    }
}
