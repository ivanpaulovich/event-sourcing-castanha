namespace MyAccountAPI.Producer.Infrastructure.Modules
{
    using Autofac;
    using MyAccountAPI.Producer.Application.Queries;
    using MyAccountAPI.Producer.Infrastructure.Queries;
    
    public class QueriesModule : Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomersQueries>()
                .As<ICustomersQueries>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();

            builder.RegisterType<AccountsQueries>()
                .As<IAccountsQueries>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();
        }
    }
}
