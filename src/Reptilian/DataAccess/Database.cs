using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

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