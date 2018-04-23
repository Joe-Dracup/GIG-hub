namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSpecifyIfArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsArtist", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsArtist");
        }
    }
}
