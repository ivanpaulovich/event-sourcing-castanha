using Autofac;
using MyAccountAPI.Consumer.Infrastructure.ServiceBus;
using MyAccountAPI.Domain.ServiceBus;

namespace MyAccountAPI.Consumer.Infrastructure.Modules
{
    public class BusModule : Module
    {
        public string BrokerList { get; set; }
        public string Topic { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Bus>()
                .As<ISubscriber>()
                .WithParameter("brokerList", BrokerList)
                .WithParameter("topic", Topic)
                .SingleInstance();
        }
    }
}
