using MediatRWrapper.Api.Commands;
using MediatRWrapper.Application.Commands;
using MediatRWrapper.Application.DomainEvents;
using MediatRWrapper.Domain;
using MediatRWrapper.Infrastructure.InMemoryStorage;

namespace MediatRWrapper.Api.CommandHandler
{
    public class AddItemCommandHandler : ICommandHandler<AddItemCommand, Guid>
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

        public async Task<CommandResult<Guid>> Handle(AddItemCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("AddItemCommand received for {ItemName}", command.Name);

                var id = Guid.NewGuid();

                var item = new Item(id, command.Name);

                _itemRepository.Save(item);

                foreach (var domainEvent in item.DomainEvents)
                {
                    await _domainEventPublisher.Publish(domainEvent, cancellationToken);
                }

                return CommandResult.Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return CommandResult<Guid>.Error(ex.Message);
            }
        }
    }
}
