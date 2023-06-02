using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatRWrapper.Api.Helpers;
using MediatRWrapper.Application.DomainEvents;
using MediatRWrapper.Domain.DomainEvents;
using Serilog;
using System.Reflection;

namespace MediatRWrapper.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((ctx, lc) => lc
                .WriteTo.Console());

            //register any Autofac modules defined in referenced assemblies
            var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies("MediatRWrapper").Distinct().ToArray();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterAssemblyModules(assemblies);
                });

            // Add services to the container

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.Run();
        }
    }
}