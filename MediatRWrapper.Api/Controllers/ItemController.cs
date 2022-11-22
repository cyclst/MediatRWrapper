using MediatRWrapper.Api.Commands;
using MediatRWrapper.Application.Commands;
using MediatRWrapper.Application.Queries;
using MediatRWrapper.Queries.FakeStorage;
using Microsoft.AspNetCore.Mvc;

namespace MediatRWrapper.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ILogger<ItemController> _logger;

        public ItemController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher,
            ILogger<ItemController> logger)
        {
            _commandDispatcher = commandDispatcher ?? throw new ArgumentNullException(nameof(commandDispatcher));
            _queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
            _logger = logger;
        }

        [ProducesResponseType(typeof(string), 200)]
        [HttpGet]
        public async Task<ActionResult> Get(CancellationToken cancellationToken)
        {
            var returnValue = await _queryDispatcher.Dispatch(new GetLatestItemQuery(), cancellationToken);

            if(returnValue.IsOk)
                return Ok(returnValue.Content);

            return BadRequest(returnValue.ErrorMessage);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string itemName, CancellationToken cancellationToken)
        {
            _logger.LogTrace($"Adding item '{itemName}'");

            var itemId = Guid.NewGuid();

            var command = new AddItemCommand(itemId, itemName);

            var commandResult = await _commandDispatcher.Dispatch(command, cancellationToken);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(itemId);
        }
    }
}