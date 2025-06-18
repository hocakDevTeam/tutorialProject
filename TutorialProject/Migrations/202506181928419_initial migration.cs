namespace TutorialProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Action = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Request_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.Request_Id)
                .Index(t => t.Request_Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShoppingListId = c.Int(nullable: false),
                        FileName = c.String(),
                        MimeType = c.String(),
                        Content = c.Binary(),
                        FileExtension = c.String(),
                        Type = c.String(),
                        SubType = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompletedBy = c.String(),
                        CompletedOn = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Location = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        ShoppingList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoppingLists", t => t.ShoppingList_Id)
                .Index(t => t.ShoppingList_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Department = c.String(),
                        Facility = c.String(),
                        Name = c.String(),
                        JobTitle = c.String(),
                        Active = c.Boolean(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingListDocuments",
                c => new
                    {
                        ShoppingList_Id = c.Int(nullable: false),
                        Document_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShoppingList_Id, t.Document_Id })
                .ForeignKey("dbo.ShoppingLists", t => t.ShoppingList_Id, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.Document_Id, cascadeDelete: true)
                .Index(t => t.ShoppingList_Id)
                .Index(t => t.Document_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Requests", "ShoppingList_Id", "dbo.ShoppingLists");
            DropForeignKey("dbo.ActivityLogs", "Request_Id", "dbo.Requests");
            DropForeignKey("dbo.ShoppingListDocuments", "Document_Id", "dbo.Documents");
            DropForeignKey("dbo.ShoppingListDocuments", "ShoppingList_Id", "dbo.ShoppingLists");
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.ShoppingListDocuments", new[] { "Document_Id" });
            DropIndex("dbo.ShoppingListDocuments", new[] { "ShoppingList_Id" });
            DropIndex("dbo.Requests", new[] { "ShoppingList_Id" });
            DropIndex("dbo.ActivityLogs", new[] { "Request_Id" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.ShoppingListDocuments");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Requests");
            DropTable("dbo.ShoppingLists");
            DropTable("dbo.Documents");
            DropTable("dbo.ActivityLogs");
        }
    }
}
