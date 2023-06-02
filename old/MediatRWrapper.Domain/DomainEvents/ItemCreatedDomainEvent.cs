using MediatRWrapper.Domain.Core;

namespace MediatRWrapper.Domain.DomainEvents
{
    public record ItemCreatedDomainEvent : IDomainEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public ItemCreatedDomainEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
