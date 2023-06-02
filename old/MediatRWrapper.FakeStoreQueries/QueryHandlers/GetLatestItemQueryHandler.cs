using MediatRWrapper.Application.Queries;
using MediatRWrapper.Domain;
using MediatRWrapper.Infrastructure.InMemoryStorage;
using MediatRWrapper.Queries.FakeStorage;
using Microsoft.Extensions.Logging;

namespace MediatRWrapper.Application.QueryHandlers
{
    public class GetLatestItemQueryHandler : IQueryHandler<GetLatestItemQuery>
    {
        private readonly FakeStore<Item> _store;
        private readonly ILogger<GetLatestItemQueryHandler> _logger;

        public GetLatestItemQueryHandler(FakeStore<Item> store,
            ILogger<GetLatestItemQueryHandler> logger)
        {
            _store = store;
            _logger = logger;
        }

        public async Task<QueryResponse> Handle(GetLatestItemQuery command, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var latestItem = _store.GetAll().OrderBy(i => i.Created).LastOrDefault();

                    if (latestItem != null)
                        return QueryResponse.Ok(latestItem.Name);

                    return QueryResponse.Error("No items added");
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
