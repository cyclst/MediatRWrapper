using Autofac;

namespace MediatRWrapper.Queries.FakeStorage;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(t => t.Name.EndsWith("QueryHandler"))
            .AsImplementedInterfaces();
    }
}
