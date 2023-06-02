using MediatRWrapper.Domain.Core;

namespace MediatRWrapper.Application.DomainEvents;

public interface IDomainEventHandler<TEvent>// where TEvent : IDomainEvent
{
    Task Handle(TEvent domainEvent, CancellationToken cancellationToken);
}
