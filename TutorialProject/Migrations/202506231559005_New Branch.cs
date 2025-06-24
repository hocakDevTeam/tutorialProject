namespace TutorialProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewBranch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityLogs", "Request_Id", c => c.Int());
            CreateIndex("dbo.ActivityLogs", "Request_Id");
            AddForeignKey("dbo.ActivityLogs", "Request_Id", "dbo.Requests", "Id");
            DropColumn("dbo.ActivityLogs", "RequestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActivityLogs", "RequestId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ActivityLogs", "Request_Id", "dbo.Requests");
            DropIndex("dbo.ActivityLogs", new[] { "Request_Id" });
            DropColumn("dbo.ActivityLogs", "Request_Id");
        }
    }
}
