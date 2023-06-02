using Autofac;

namespace MediatRWrapper.Infrastructure;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(t => t.Name.EndsWith("CommandHandler"))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(t => t.Name.EndsWith("DomainEventHandler"))
            .AsImplementedInterfaces();
    }
}
