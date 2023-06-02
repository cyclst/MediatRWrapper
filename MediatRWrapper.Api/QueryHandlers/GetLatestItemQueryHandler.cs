using MediatR;
using MediatRWrapper.Api.Queries;
using MediatRWrapper.Application.Commands;
using MediatRWrapper.Domain;
using MediatRWrapper.Infrastructure.InMemoryStorage;

namespace MediatRWrapper.Api.QueryHandlers
{
    public class GetLatestItemQueryHandler : ICommandHandler<GetLatestItemQuery, string>
    {
        private readonly FakeStore<Item> _store;
        private readonly ILogger<GetLatestItemQueryHandler> _logger;

        public GetLatestItemQueryHandler(FakeStore<Item> store,
            ILogger<GetLatestItemQueryHandler> logger)
        {
            _store = store;
            _logger = logger;
        }

        public async Task<CommandResult<string>> Handle(GetLatestItemQuery command, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var latestItem = _store.GetAll().OrderBy(i => i.Created).LastOrDefault();

                    if (latestItem != null)
                        return CommandResult.Ok(latestItem.Name);

                    return CommandResult<string>.Error("No items added");
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                throw new ApplicationException("Query error");
            }
        }
    }
}
