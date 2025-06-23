namespace TutorialProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivityLogs", "Request_Id", "dbo.Requests");
            DropIndex("dbo.ActivityLogs", new[] { "Request_Id" });
            RenameColumn(table: "dbo.ActivityLogs", name: "Request_Id", newName: "RequestId");
            AlterColumn("dbo.ActivityLogs", "RequestId", c => c.Int(nullable: false));
            CreateIndex("dbo.ActivityLogs", "RequestId");
            AddForeignKey("dbo.ActivityLogs", "RequestId", "dbo.Requests", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivityLogs", "RequestId", "dbo.Requests");
            DropIndex("dbo.ActivityLogs", new[] { "RequestId" });
            AlterColumn("dbo.ActivityLogs", "RequestId", c => c.Int());
            RenameColumn(table: "dbo.ActivityLogs", name: "RequestId", newName: "Request_Id");
            CreateIndex("dbo.ActivityLogs", "Request_Id");
            AddForeignKey("dbo.ActivityLogs", "Request_Id", "dbo.Requests", "Id");
        }
    }
}
