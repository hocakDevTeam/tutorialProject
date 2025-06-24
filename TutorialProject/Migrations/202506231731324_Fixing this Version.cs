namespace TutorialProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingthisVersion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivityLogs", "Request_Id", "dbo.Requests");
            DropIndex("dbo.ActivityLogs", new[] { "Request_Id" });
            AddColumn("dbo.ActivityLogs", "RequestId", c => c.Int(nullable: false));
            DropColumn("dbo.ActivityLogs", "Request_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActivityLogs", "Request_Id", c => c.Int());
            DropColumn("dbo.ActivityLogs", "RequestId");
            CreateIndex("dbo.ActivityLogs", "Request_Id");
            AddForeignKey("dbo.ActivityLogs", "Request_Id", "dbo.Requests", "Id");
        }
    }
}
