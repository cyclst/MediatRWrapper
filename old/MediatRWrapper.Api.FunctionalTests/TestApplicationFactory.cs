using Autofac;
using MediatRWrapper.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PureGym.IdentityServer.Web.IntegrationTests
{
    public class TestApplicationFactory
            : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureContainer<ContainerBuilder>(builder =>
            {
                //builder.RegisterType<InMemoryActivityRepository>().As<IActivityRepository>().SingleInstance();
                //builder.RegisterType<FakeUserAchievementsRepository>().As<IUserAchievementsRepository>().SingleInstance();
            });

            builder.ConfigureHostConfiguration((config) =>
            {
                //config.AddInMemoryCollection(
                //    new Dictionary<string, string?>
                //    {
                //        ["ConnectionString"] = @"Data Source=(LocalDb)\MSSQLLocalDB;database=Activities;trusted_connection=yes;"
                //    });
            });

            return base.CreateHost(builder);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("IntegrationTesting");

            builder.ConfigureTestServices(services =>
            {
                //services.AddSingleton<IEventBus, InMemoryEventBus>();
            });
        }
    }
}
