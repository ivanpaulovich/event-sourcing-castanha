namespace Castanha.UI.Modules
{
    using Autofac;
    using Castanha.Application.ServiceBus;
    using Castanha.Infrastructure.ServiceBus;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Castanha.Application
            //
            // IPublisher
            // ISubscriber
            // IInputBoundary<>
            // IOutputBoundary<>
            //
            builder.RegisterAssemblyTypes(typeof(Application.UseCases.Register.RegisterInteractor).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
