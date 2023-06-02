namespace MediatRWrapper.Application.Queries;

public interface IQueryDispatcher
{
    Task<QueryResponse> Dispatch<TQuery>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery;
}