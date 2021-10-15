using System;
using System.Diagnostics.CodeAnalysis;
using FluentMigrator;

namespace Reptilian.DataAccess.Migrations
{
    public abstract class UpOnlyMigration : Migration
    {
        /// <summary>
        /// Do not override/implement this method.
        /// </summary>
        /// <remarks>We never roll back, so no need to implement this method.</remarks>
        /// <exception cref="NotImplementedException">Thrown at all times.</exception>
        [SuppressMessage("General", "RCS1079:Throwing of new NotImplementedException", Justification = "Method not needed.")]
        public sealed override void Down()
        {
            // sealed means derived classes cannot accidentally override this method
            throw new NotImplementedException();
        }

        public abstract override void Up();
    }
}