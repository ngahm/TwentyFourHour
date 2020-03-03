namespace TwentyFourHour.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        AuthorID = c.Guid(nullable: false),
                        CommentPostID = c.Int(nullable: false),
                        ReplyCommentID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.User", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.CommentPostID, cascadeDelete: true)
                .ForeignKey("dbo.Comment", t => t.ReplyCommentID)
                .Index(t => t.AuthorID)
                .Index(t => t.CommentPostID)
                .Index(t => t.ReplyCommentID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        AuthorID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LikePostID = c.Int(nullable: false),
                        LikerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Post", t => t.LikePostID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.LikerID, cascadeDelete: true)
                .Index(t => t.LikePostID)
                .Index(t => t.LikerID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Like", "LikerID", "dbo.User");
            DropForeignKey("dbo.Like", "LikePostID", "dbo.Post");
            DropForeignKey("dbo.Comment", "ReplyCommentID", "dbo.Comment");
            DropForeignKey("dbo.Comment", "CommentPostID", "dbo.Post");
            DropForeignKey("dbo.Post", "AuthorID", "dbo.User");
            DropForeignKey("dbo.Comment", "AuthorID", "dbo.User");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Like", new[] { "LikerID" });
            DropIndex("dbo.Like", new[] { "LikePostID" });
            DropIndex("dbo.Post", new[] { "AuthorID" });
            DropIndex("dbo.Comment", new[] { "ReplyCommentID" });
            DropIndex("dbo.Comment", new[] { "CommentPostID" });
            DropIndex("dbo.Comment", new[] { "AuthorID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Like");
            DropTable("dbo.Post");
            DropTable("dbo.User");
            DropTable("dbo.Comment");
        }
    }
}
