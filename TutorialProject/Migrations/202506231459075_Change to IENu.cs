namespace TutorialProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangetoIENu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivityLogs", "RequestId", "dbo.Requests");
            DropIndex("dbo.ActivityLogs", new[] { "RequestId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.ActivityLogs", "RequestId");
            AddForeignKey("dbo.ActivityLogs", "RequestId", "dbo.Requests", "Id", cascadeDelete: true);
        }
    }
}
