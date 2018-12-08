namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GenreId = c.String(),
                        ArtistId = c.String(),
                        PublisherDate = c.DateTime(nullable: false),
                        AlbumArtUrl = c.String(),
                        Artist_ID = c.Guid(),
                        Genre_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Artists", t => t.Artist_ID)
                .ForeignKey("dbo.Genres", t => t.Genre_ID)
                .Index(t => t.Artist_ID)
                .Index(t => t.Genre_ID);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Sex = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ApplicaitionUserInApplications",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 10),
                        SortCode = c.String(maxLength: 50),
                        AppInfo_ID = c.Guid(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationInformations", t => t.AppInfo_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.AppInfo_ID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ApplicationInformations",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        SortCode = c.String(maxLength: 50),
                        AppID = c.Guid(nullable: false),
                        AppShortName = c.String(maxLength: 100),
                        AppDisplayName = c.String(maxLength: 100),
                        AppFullUrl = c.String(maxLength: 100),
                        AppDesktopFullUrl = c.String(maxLength: 100),
                        AppSSOFullUrl = c.String(maxLength: 100),
                        AppVersion = c.String(maxLength: 100),
                        AppIconString = c.String(maxLength: 100),
                        IsDefault = c.Boolean(nullable: false),
                        AppType_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationBusinessTypes", t => t.AppType_ID)
                .Index(t => t.AppType_ID);
            
            CreateTable(
                "dbo.ApplicationBusinessTypes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        SortCode = c.String(maxLength: 50),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        ChineseFullName = c.String(maxLength: 100),
                        MobileNumber = c.String(maxLength: 50),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Person_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_ID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Person_ID);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 1000),
                        SortCode = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Sex = c.Boolean(nullable: false),
                        TelephoneNumber = c.String(maxLength: 20),
                        MobileNumber = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        Birthday = c.DateTime(nullable: false),
                        CredentialsCode = c.String(maxLength: 26),
                        UpdateTime = c.DateTime(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        InquiryPassword = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        DisplayName = c.String(maxLength: 250),
                        Description = c.String(maxLength: 550),
                        SortCode = c.String(maxLength: 50),
                        ApplicationRoleType = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ApplicaitionUserInApplications", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Person_ID", "dbo.People");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicaitionUserInApplications", "AppInfo_ID", "dbo.ApplicationInformations");
            DropForeignKey("dbo.ApplicationInformations", "AppType_ID", "dbo.ApplicationBusinessTypes");
            DropForeignKey("dbo.Albums", "Genre_ID", "dbo.Genres");
            DropForeignKey("dbo.Albums", "Artist_ID", "dbo.Artists");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Person_ID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ApplicationInformations", new[] { "AppType_ID" });
            DropIndex("dbo.ApplicaitionUserInApplications", new[] { "User_Id" });
            DropIndex("dbo.ApplicaitionUserInApplications", new[] { "AppInfo_ID" });
            DropIndex("dbo.Albums", new[] { "Genre_ID" });
            DropIndex("dbo.Albums", new[] { "Artist_ID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.People");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ApplicationBusinessTypes");
            DropTable("dbo.ApplicationInformations");
            DropTable("dbo.ApplicaitionUserInApplications");
            DropTable("dbo.Genres");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
