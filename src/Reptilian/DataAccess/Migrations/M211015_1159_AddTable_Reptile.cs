using FluentMigrator;

namespace Reptilian.DataAccess.Migrations
{
    [Migration(211015_1159)]
    public class M211015_1159_AddTable_Reptile : Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Reptile")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Breed").AsString().NotNullable()
                .WithColumn("Name").AsString().NotNullable();
        }
    }
}