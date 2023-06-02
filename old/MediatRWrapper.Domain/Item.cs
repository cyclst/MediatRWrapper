using MediatRWrapper.Domain.Core;
using MediatRWrapper.Domain.DomainEvents;

namespace MediatRWrapper.Domain
{
    public class Item : AggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public DateTime Created { get; private set; }

        public Item(Guid id, string name)
        {
            Id = id;
            Name = name;
            Created = DateTime.Now;

            PublishDomainEvent(new ItemCreatedDomainEvent(Id, Name));
        }
    }
}
