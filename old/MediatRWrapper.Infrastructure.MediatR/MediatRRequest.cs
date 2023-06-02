using MediatR;

namespace MediatRWrapper.Infrastructure.MediatR;

public class MediatRRequest<TRequest, TResponse> : IRequest<TResponse>
{
    private TRequest _request;
    public TRequest Request => _request;

    public MediatRRequest(TRequest request)
    {
        _request = request;
    }
}
