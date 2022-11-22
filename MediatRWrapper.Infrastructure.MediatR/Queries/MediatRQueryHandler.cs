using MediatR;
using MediatRWrapper.Application.Queries;

namespace MediatRWrapper.Infrastructure.MediatR.Queries
{
    public class MediatRQueryHandler<TQuery> : IRequestHandler<MediatRRequest<TQuery, QueryResponse>, QueryResponse>
        where TQuery : IQuery
    {
        private readonly List<IQueryHandler<TQuery>> _handlers;

        public MediatRQueryHandler(IEnumerable<IQueryHandler<TQuery>> handlers)
        {
            _handlers = handlers.ToList() ?? throw new ArgumentNullException(nameof(handlers));

            if (_handlers.Count > 1)
                throw new ApplicationException("More than one event handler registered");
        }

        public async Task<QueryResponse> Handle(MediatRRequest<TQuery, QueryResponse> request, CancellationToken cancellationToken)
        {
            var handler = _handlers.First();

            return await handler.Handle(request.Request, cancellationToken);
        }
    }
}