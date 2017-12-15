using Autofac;
using MyAccountAPI.Consumer.Infrastructure.DataAccess;
using MyAccountAPI.Consumer.Infrastructure.DataAccess.Repositories.Accounts;
using MyAccountAPI.Consumer.Infrastructure.DataAccess.Repositories.Customers;
using MyAccountAPI.Domain.Model.Accounts;
using MyAccountAPI.Domain.Model.Customers;

namespace MyAccountAPI.Consumer.Infrastructure.Modules
{
    public class ApplicationModule : Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            MongoContext mongoContext = new MongoContext(ConnectionString, DatabaseName);
            mongoContext.DatabaseReset(DatabaseName);

            builder.Register(c => mongoContext)
                .As<MongoContext>().SingleInstance();

            builder.RegisterType<CustomerReadOnlyRepository>()
                .As<ICustomerReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerWriteOnlyRepository>()
                .As<ICustomerWriteOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountReadOnlyRepository>()
                .As<IAccountReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountWriteOnlyRepository>()
                .As<IAccountWriteOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
