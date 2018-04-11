namespace Castanha.Infrastructure.Modules
{
    using Autofac;
    using Castanha.Application.ServiceBus;
    using Castanha.Infrastructure.ServiceBus;
    public class BusModule : Autofac.Module
    {
        public string BrokerList { get; set; }
        public string Topic { get; set; }
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register the Bus
            //
            // IPublisher
            // ISubscriber
            //
            builder.RegisterType<Bus>()
                .As<IPublisher>()
                .As<ISubscriber>()
                .WithParameter("brokerList", BrokerList)
                .WithParameter("topic", Topic)
                .SingleInstance();
        }
    }
}
