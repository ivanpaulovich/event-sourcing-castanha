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
        public readonly string connectionString;
        public readonly string database;

        public ApplicationModule(string connectionString, string database)
        {
            this.connectionString = connectionString;
            this.database = database;
        }

        protected override void Load(ContainerBuilder builder)
        {
            MongoContext mongoContext = new MongoContext(connectionString, database);
            mongoContext.DatabaseReset(database);

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
