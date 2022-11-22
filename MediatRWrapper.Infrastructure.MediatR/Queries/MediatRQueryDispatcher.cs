using MediatR;
using MediatRWrapper.Application.Queries;

namespace MediatRWrapper.Infrastructure.MediatR.Queryies
{
    public class MediatRQueryDispatcher : IQueryDispatcher
    {
        private readonly IMediator _mediator;

        public MediatRQueryDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<QueryResponse> Dispatch<TQuery>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery
        {
            return await _mediator.Send(new MediatRRequest<TQuery, QueryResponse>(query), cancellationToken);
        }
    }
}