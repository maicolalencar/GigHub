namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Gigs", name: "Artist_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Gigs", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Gigs", name: "IX_Artist_Id", newName: "IX_ApplicationUserId");
            RenameIndex(table: "dbo.Gigs", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Gigs", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.Gigs", name: "IX_ApplicationUserId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Gigs", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Gigs", name: "ApplicationUserId", newName: "Artist_Id");
        }
    }
}
