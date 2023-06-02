using Autofac;
using MediatR;
using MediatRWrapper.Application.Commands;
using MediatRWrapper.Application.DomainEvents;

namespace MediatRWrapper.Application
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .SingleInstance();

            builder.RegisterType<MediatRCommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<MediatRDomainEventPublisher>().As<IDomainEventPublisher>();
        }
    }
}
