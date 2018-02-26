namespace MyAccountAPI.Producer.UI.Modules
{
    using Autofac;
    using MyAccountAPI.Producer.Application;
    using MyAccountAPI.Producer.UI.Presenters;

    public class UIModuley : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in MyAccountAPI.Producer.UI
            //
            builder.RegisterAssemblyTypes(typeof(RegisterPresenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}
