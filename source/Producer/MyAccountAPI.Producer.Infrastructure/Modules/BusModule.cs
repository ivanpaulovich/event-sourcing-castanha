namespace MyAccountAPI.Producer.Infrastructure.Modules
{
    using Autofac;
    using MyAccountAPI.Domain.ServiceBus;
    using MyAccountAPI.Producer.Infrastructure.ServiceBus;

    public class BusModule : Module
    {
        public string BrokerList { get; set; }
        public string Topic { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Bus>()
                .As<IPublisher>()
                .WithParameter("brokerList", BrokerList)
                .WithParameter("topic", Topic)
                .SingleInstance();
        }
    }
}
