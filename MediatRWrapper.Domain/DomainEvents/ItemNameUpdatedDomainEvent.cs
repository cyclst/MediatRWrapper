using MediatRWrapper.Domain.Core;

namespace MediatRWrapper.Domain.DomainEvents
{
    public record ItemNameUpdatedDomainEvent : IDomainEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public ItemNameUpdatedDomainEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
