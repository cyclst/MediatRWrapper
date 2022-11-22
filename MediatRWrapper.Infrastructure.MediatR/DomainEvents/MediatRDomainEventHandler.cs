using MediatR;
using MediatRWrapper.Application.DomainEvents;
using MediatRWrapper.Domain.Core;

namespace MediatRWrapper.Infrastructure.MediatR.DomainEvents
{
    public class MediatRDomainEventHandler<TDomainEvent> : INotificationHandler<MediatRDomainEvent<TDomainEvent>>
        where TDomainEvent : IDomainEvent
    {
        private readonly List<IDomainEventHandler<TDomainEvent>> _handlers;

        public MediatRDomainEventHandler(IEnumerable<IDomainEventHandler<TDomainEvent>> handlers)
        {
            _handlers = handlers.ToList() ?? throw new ArgumentNullException(nameof(handlers));
        }

        public async Task Handle(MediatRDomainEvent<TDomainEvent> request, CancellationToken cancellationToken)
        {
            var handler = _handlers.First();

            await handler.Handle(request.Event, cancellationToken);
        }
    }
}