using MediatRWrapper.Domain.Core;

namespace MediatRWrapper.Application.DomainEvents;

public interface IDomainEventPublisher
{
    Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IDomainEvent;
}
