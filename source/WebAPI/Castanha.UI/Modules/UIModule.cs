namespace Castanha.UI.Modules
{
    using Autofac;
    using Castanha.Application;
    using Castanha.UI.Presenters;

    public class UIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Presenters in Castanha.UI
            //
            builder.RegisterAssemblyTypes(typeof(RegisterPresenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}
