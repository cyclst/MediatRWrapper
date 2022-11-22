using MediatRWrapper.Application.DomainEvents;
using MediatRWrapper.Domain.DomainEvents;

namespace MediatRWrapper.Api.DomainEventHandlers
{
    public class ItemCreatedDomainEventHandler : IDomainEventHandler<ItemCreatedDomainEvent>
    {
        private readonly ILogger<ItemCreatedDomainEventHandler> _logger;

        public ItemCreatedDomainEventHandler(ILogger<ItemCreatedDomainEventHandler> logger) {
            _logger = logger;
        }
        public async Task Handle(ItemCreatedDomainEvent itemCreatedDomainEvent, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _logger.LogInformation("ItemCreatedDomainEvent received for {ItemName}", itemCreatedDomainEvent.Name);
            });
        }
    }
}
