namespace MyAccountAPI.Producer.Infrastructure.Modules
{
    using Autofac;
    using MyAccountAPI.Domain.Model.Accounts;
    using MyAccountAPI.Domain.Model.Customers;
    using MyAccountAPI.Producer.Infrastructure.DataAccess;
    using MyAccountAPI.Producer.Infrastructure.DataAccess.Repositories.Accounts;
    using MyAccountAPI.Producer.Infrastructure.DataAccess.Repositories.Customers;

    public class ApplicationModule : Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoContext>()
                .As<MongoContext>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();

            builder.RegisterType<CustomerReadOnlyRepository>()
                .As<ICustomerReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountReadOnlyRepository>()
                .As<IAccountReadOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
