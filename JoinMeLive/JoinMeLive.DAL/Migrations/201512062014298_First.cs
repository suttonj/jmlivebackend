namespace JoinMeLive.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ParentCategoryId = c.Long(),
                        Name = c.String(nullable: false),
                        ActiveUntil = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.Discussions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        ViewerCode = c.Long(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagDiscussions",
                c => new
                    {
                        Tag_Id = c.Long(nullable: false),
                        Discussion_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Discussion_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Discussions", t => t.Discussion_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Discussion_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagDiscussions", "Discussion_Id", "dbo.Discussions");
            DropForeignKey("dbo.TagDiscussions", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Discussions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropIndex("dbo.TagDiscussions", new[] { "Discussion_Id" });
            DropIndex("dbo.TagDiscussions", new[] { "Tag_Id" });
            DropIndex("dbo.Discussions", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            DropTable("dbo.TagDiscussions");
            DropTable("dbo.Tags");
            DropTable("dbo.Discussions");
            DropTable("dbo.Categories");
        }
    }
}
