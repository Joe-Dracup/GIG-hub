namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataModelToAllowUsersToFollow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FoloweeId = c.String(nullable: false, maxLength: 128),
                        Followee_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FoloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.Followee_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId, cascadeDelete: true)
                .Index(t => t.FollowerId)
                .Index(t => t.Followee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "Followee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "Followee_Id" });
            DropIndex("dbo.Follows", new[] { "FollowerId" });
            DropTable("dbo.Follows");
        }
    }
}
