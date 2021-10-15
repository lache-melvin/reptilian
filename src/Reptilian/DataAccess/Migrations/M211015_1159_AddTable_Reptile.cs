using FluentMigrator;

namespace Reptilian.DataAccess.Migrations
{
    [Migration(211015_1159)]
    public class M211015_1159_AddTable_Reptile : UpOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Reptile")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Breed").AsString().NotNullable()
                .WithColumn("Name").AsString().NotNullable();
        }
    }
}