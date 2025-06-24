namespace TutorialProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomethingElse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityLogs", "ShoppingList_Id", c => c.Int());
            CreateIndex("dbo.ActivityLogs", "ShoppingList_Id");
            AddForeignKey("dbo.ActivityLogs", "ShoppingList_Id", "dbo.ShoppingLists", "Id");
            DropColumn("dbo.Documents", "Type");
            DropColumn("dbo.Documents", "SubType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "SubType", c => c.String());
            AddColumn("dbo.Documents", "Type", c => c.String());
            DropForeignKey("dbo.ActivityLogs", "ShoppingList_Id", "dbo.ShoppingLists");
            DropIndex("dbo.ActivityLogs", new[] { "ShoppingList_Id" });
            DropColumn("dbo.ActivityLogs", "ShoppingList_Id");
        }
    }
}
