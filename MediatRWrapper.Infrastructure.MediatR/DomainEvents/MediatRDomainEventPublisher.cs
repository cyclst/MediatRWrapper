using MediatR;
using MediatRWrapper.Application.DomainEvents;
using MediatRWrapper.Domain.Core;

namespace MediatRWrapper.Infrastructure.MediatR.DomainEvents
{
    public class MediatRDomainEventPublisher : IDomainEventPublisher
    {
        private readonly IMediator _mediator;

        public MediatRDomainEventPublisher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IDomainEvent
        {
            await _mediator.Publish(new MediatRDomainEvent<TEvent>(@event), cancellationToken);
        }
    }
}