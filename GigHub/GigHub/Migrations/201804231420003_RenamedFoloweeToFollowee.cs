namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedFoloweeToFollowee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Follows", "Followee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "Followee_Id" });
            RenameColumn(table: "dbo.Follows", name: "Followee_Id", newName: "FolloweeId");
            DropPrimaryKey("dbo.Follows");
            AlterColumn("dbo.Follows", "FolloweeId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Follows", new[] { "FollowerId", "FolloweeId" });
            CreateIndex("dbo.Follows", "FolloweeId");
            AddForeignKey("dbo.Follows", "FolloweeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Follows", "FoloweeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Follows", "FoloweeId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Follows", "FolloweeId", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "FolloweeId" });
            DropPrimaryKey("dbo.Follows");
            AlterColumn("dbo.Follows", "FolloweeId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Follows", new[] { "FollowerId", "FoloweeId" });
            RenameColumn(table: "dbo.Follows", name: "FolloweeId", newName: "Followee_Id");
            CreateIndex("dbo.Follows", "Followee_Id");
            AddForeignKey("dbo.Follows", "Followee_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
