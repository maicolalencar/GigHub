namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddMPBSamba : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (Id, Name) Values (5,'MPB')");
            Sql("insert into Genres (Id, Name) Values (6,'Samba')");
            Sql("insert into Genres (Id, Name) Values (7,'Bossa Nova')");
        }

        public override void Down()
        {
            Sql("Delete from Genres where Id in (5,6,7)");

        }
    }
}
