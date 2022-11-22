using MediatR;

namespace MediatRWrapper.Infrastructure.MediatR.DomainEvents;

public class MediatRDomainEvent<TEvent> :  INotification
{
    private TEvent _event;
    public TEvent Event => _event;

    public MediatRDomainEvent(TEvent @event)
    {
        _event = @event;
    }
}
