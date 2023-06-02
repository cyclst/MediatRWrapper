using Autofac;
using MediatRWrapper.Domain;

namespace MediatRWrapper.Infrastructure.InMemoryStorage
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(FakeStore<Item>)).AsSelf().SingleInstance(); // We also add this to DI so we can query it without having to go via the domain aggregate repo. It's CQRS baby!
            builder.RegisterType<ItemRepository>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
