using MediatRWrapper.Api.Commands;
using MediatRWrapper.Application.Commands;
using MediatRWrapper.Application.DomainEvents;
using MediatRWrapper.Domain;
using MediatRWrapper.Domain.DomainEvents;
using MediatRWrapper.Infrastructure.FakeStorage;

namespace MediatRWrapper.Api.CommandHandler
{
    public class AddItemCommandHandler : ICommandHandler<AddItemCommand>
    {
        private readonly IDomainEventPublisher _domainEventPublisher;
        private readonly IItemRepository _itemRepository;
        private readonly ILogger<AddItemCommandHandler> _logger;

        public AddItemCommandHandler(IDomainEventPublisher domainEventPublisher,
            IItemRepository itemRepository,
            ILogger<AddItemCommandHandler> logger)
        {
            _domainEventPublisher = domainEventPublisher;
            _itemRepository = itemRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(AddItemCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("AddItemCommand received for {ItemName}", command.Name);

                var item = new Item(command.Id, command.Name);

                _itemRepository.Save(item);

                foreach (var domainEvent in item.DomainEvents)
                {
                    await _domainEventPublisher.Publish(domainEvent, cancellationToken);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return false;
            }
        }
    }
}
