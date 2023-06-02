using MediatRWrapper.Api.Commands;
using MediatRWrapper.Application.Commands;
using MediatRWrapper.Application.DomainEvents;
using MediatRWrapper.Infrastructure.InMemoryStorage;

namespace MediatRWrapper.Api.CommandHandler
{
    public class UpdateItemCommandHandler : ICommandHandler<UpdateItemCommand>
    {
        private readonly IDomainEventPublisher _domainEventPublisher;
        private readonly IItemRepository _itemRepository;
        private readonly ILogger<AddItemCommandHandler> _logger;

        public UpdateItemCommandHandler(IDomainEventPublisher domainEventPublisher,
            IItemRepository itemRepository,
            ILogger<AddItemCommandHandler> logger)
        {
            _domainEventPublisher = domainEventPublisher;
            _itemRepository = itemRepository;
            _logger = logger;
        }

        public async Task<CommandResult> Handle(UpdateItemCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("UpdateItemCommand received for {ItemName}", command.Name);

                var item = _itemRepository.Get(command.Id);

                item.UpdateName(command.Name);

                _itemRepository.Save(item);

                foreach (var domainEvent in item.DomainEvents)
                {
                    await _domainEventPublisher.Publish(domainEvent, cancellationToken);
                }

                return CommandResult.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return CommandResult.Error(ex.Message);
            }
        }
    }
}
