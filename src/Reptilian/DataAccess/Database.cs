using System;
using FluentMigrator.Runner;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace Reptilian.DataAccess
{
    public class Database
    {
        public static void RunMigrations()
        {
            var serviceProvider = CreateServices();

            // Put db update into a scope to ensure all resources are disposed
            using (var scope = serviceProvider.CreateScope())
            {
                RunMigrations(scope.ServiceProvider);
            }
        }

        /// <summary>
        ///  Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(ConnectionString)
                .ScanIn(typeof(Database).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
        }

        // Session factories are expensive to create (usually create one instance
        // within application). Session factory will manage the pool of sessions.
        // A session (a connection with the DB) is cheap to create - whenever you
        // need to interact with the DB, get a session from the session factory,
        // and close it once you are done.
        public static ISessionFactory CreateSessionFactory()
        {
            RunMigrations();
            return Fluently.Configure()
            .Database(
                MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString)
            )
            .Mappings(m => m.FluentMappings
                .AddFromAssemblyOf<Database>()
                .Conventions.Add(FluentNHibernate.Conventions.Helpers.ForeignKey.EndsWith("Id"))
            )
            .BuildSessionFactory();
        }

        /// <summary>
        ///  Update the database
        /// </summary>
        private static void RunMigrations(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
        private const string ConnectionString = "Server=db,1433;Database=reptilian-cli;User Id=sa;Password=Pa55word!";
    }
}