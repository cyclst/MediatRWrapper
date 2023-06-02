using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MediatRWrapper.Application.DomainEvents
{
    public class MediatRDomainEvent<TEvent> : INotification
    {
        private TEvent _event;
        public TEvent Event => _event;

        public MediatRDomainEvent(TEvent @event)
        {
            _event = @event;
        }
    }
}
