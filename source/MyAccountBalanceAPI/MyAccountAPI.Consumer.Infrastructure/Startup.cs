using Autofac;
using Autofac.Extensions.DependencyInjection;
using MyAccountAPI.Consumer.Application.DomainEventHandlers.Blogs;
using MyAccountAPI.Consumer.Infrastructure.Modules;
using MyAccountAPI.Domain.ServiceBus;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading;
using MyAccountAPI.Consumer.Application.DomainEventHandlers.Customers;

namespace MyAccountAPI.Consumer.Infrastructure
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        IServiceProvider serviceProvider;

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(RegisteredEventHandler).GetTypeInfo().Assembly);

            ContainerBuilder container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new ApplicationModule(
                Configuration.GetSection("MongoDB").GetValue<string>("ConnectionString"),
                Configuration.GetSection("MongoDB").GetValue<string>("Database")));

            container.RegisterModule(new BusModule(
                Configuration.GetSection("ServiceBus").GetValue<string>("ConnectionString"),
                Configuration.GetSection("ServiceBus").GetValue<string>("Topic")));

            serviceProvider = new AutofacServiceProvider(container.Build());

            return serviceProvider;
        }

        public void Run()
        {
            IMediator mediator = serviceProvider.GetService<IMediator>();
            ISubscriber subscriber = serviceProvider.GetService<ISubscriber>();

            subscriber.Listen(mediator);

            while (true)
            {
                Thread.Sleep(1000 * 60);
            }
        }
    }
}
