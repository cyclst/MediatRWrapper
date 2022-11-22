using Autofac;
using MediatR;
using MediatRWrapper.Infrastructure.MediatR.Commands;
using MediatRWrapper.Infrastructure.MediatR.DomainEvents;
using MediatRWrapper.Infrastructure.MediatR.Queries;

namespace MediatRWrapper.Infrastructure.MediatR;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Mediator>()
            .As<IMediator>()
            .SingleInstance();

        builder.Register<ServiceFactory>(ctx =>
        {
            var c = ctx.Resolve<IComponentContext>();
            return t => c.Resolve(t);
        });

        builder.RegisterGeneric(typeof(MediatRCommandHandler<>)).AsImplementedInterfaces();
        builder.RegisterGeneric(typeof(MediatRQueryHandler<>)).AsImplementedInterfaces();
        builder.RegisterGeneric(typeof(MediatRDomainEventHandler<>)).AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(t => t.Name.EndsWith("CommandDispatcher"))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(t => t.Name.EndsWith("QueryDispatcher"))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(t => t.Name.EndsWith("DomainEventPublisher"))
            .AsImplementedInterfaces();
    }
}
