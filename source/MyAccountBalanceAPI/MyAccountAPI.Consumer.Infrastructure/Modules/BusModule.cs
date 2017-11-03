using Autofac;
using MyAccountAPI.Consumer.Infrastructure.ServiceBus;
using MyAccountAPI.Domain.ServiceBus;
using MediatR;

namespace MyAccountAPI.Consumer.Infrastructure.Modules
{
    public class BusModule : Module
    {
        private readonly string brokerList;
        private readonly string topic;

        public BusModule(string brokerList, string topic)
        {
            this.brokerList = brokerList;
            this.topic = topic;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Bus>()
                .As<ISubscriber>()
                .WithParameter("brokerList", brokerList)
                .WithParameter("topic", topic)
                .SingleInstance();
        }
    }
}
