using Autofac;
using MyAccountAPI.Domain.Model.Blogs;
using MyAccountAPI.Domain.Model.Posts;
using MyAccountAPI.Consumer.Infrastructure;
using MyAccountAPI.Consumer.Infrastructure.DataAccess.Repositories;
using MyAccountAPI.Consumer.Infrastructure.DataAccess.Repositories.Blogs;
using MyAccountAPI.Consumer.Infrastructure.DataAccess.Repositories.Posts;
using MyAccountAPI.Consumer.Infrastructure.DataAccess;

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

            builder.RegisterType<BlogReadOnlyRepository>()
                .As<IBlogReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogWriteOnlyRepository>()
                .As<IBlogWriteOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostReadOnlyRepository>()
                .As<IPostReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostWriteOnlyRepository>()
                .As<IPostWriteOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
