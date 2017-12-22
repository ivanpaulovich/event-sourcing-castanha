namespace MyAccountAPI.Consumer.Infrastructure.Modules
{
    using Autofac;
    using Autofac.Features.Variance;
    using MediatR;
    using MyAccountAPI.Consumer.Application.DomainEventHandlers.Customers;
    using System.Collections.Generic;
    using System.Reflection;

    public class MediatRModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder
                .Register<SingleInstanceFactory>(ctx => {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => { object o; return c.TryResolve(t, out o) ? o : null; };
                })
                .InstancePerLifetimeScope();

            builder
                .Register<MultiInstanceFactory>(ctx => {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                })
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(RegisteredEventHandler).GetTypeInfo().Assembly).AsImplementedInterfaces(); // via assembly scan
        }
    }
}
