using MediatRWrapper.Api.Commands;
using MediatRWrapper.Api.Queries;
using MediatRWrapper.Application.Commands;
//using MediatRWrapper.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRWrapper.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ILogger<ItemController> _logger;

        public ItemController(ICommandDispatcher commandDispatcher,
            ILogger<ItemController> logger)
        {
            _commandDispatcher = commandDispatcher ?? throw new ArgumentNullException(nameof(commandDispatcher));
            _logger = logger;
        }

        [ProducesResponseType(typeof(string), 200)]
        [HttpGet]
        public async Task<ActionResult> Get(CancellationToken cancellationToken)
        {
            var returnValue = await _commandDispatcher.Dispatch(new GetLatestItemQuery(), cancellationToken);

            if (returnValue.Success)
                return Ok(returnValue.Content);

            return BadRequest(returnValue.ErrorMessage);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string name, CancellationToken cancellationToken)
        {
            _logger.LogTrace($"Adding item '{name}'");

            var command = new AddItemCommand(name);

            var commandResult = await _commandDispatcher.Dispatch(command, cancellationToken);

            if (!commandResult.Success)
            {
                return BadRequest();
            }

            return Ok(commandResult.Content);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id, string name, CancellationToken cancellationToken)
        {
            _logger.LogTrace($"Updating item '{id}'");

            var command = new UpdateItemCommand(id, name);

            var commandResult = await _commandDispatcher.Dispatch(command, cancellationToken);

            if (!commandResult.Success)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}