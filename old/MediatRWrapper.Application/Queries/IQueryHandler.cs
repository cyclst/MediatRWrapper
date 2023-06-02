namespace MediatRWrapper.Application.Queries;

public interface IQueryHandler<TQuery> where TQuery : IQuery
{
    Task<QueryResponse> Handle(TQuery command, CancellationToken cancellationToken);
}
