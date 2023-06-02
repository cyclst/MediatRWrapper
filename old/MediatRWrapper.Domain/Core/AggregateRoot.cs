using System;
using System.Collections.Concurrent;

namespace MediatRWrapper.Domain.Core
{
    public abstract class AggregateRoot
    {
        // Very important the list is of type dynamic not IDomainEvent so the added event does not loose its type, which would prevent it from being handled
        private ConcurrentQueue<dynamic> _domainEvents= new ConcurrentQueue<dynamic>();
        public IReadOnlyList<dynamic> DomainEvents => _domainEvents.ToList();

        public void PublishDomainEvent(IDomainEvent domainEvent)
        {
            // These will actually be published by the application layer
            _domainEvents.Enqueue(domainEvent);
        }
    }
}
