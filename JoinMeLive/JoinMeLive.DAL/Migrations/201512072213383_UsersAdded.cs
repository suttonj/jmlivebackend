namespace JoinMeLive.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DisplayName = c.String(),
                        PhotoUrl = c.String(),
                        SelfSummary = c.String(),
                        LastLogin = c.DateTime(),
                        Login = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tags", "User_Id", c => c.Long());
            CreateIndex("dbo.Tags", "User_Id");
            AddForeignKey("dbo.Tags", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "User_Id", "dbo.Users");
            DropIndex("dbo.Tags", new[] { "User_Id" });
            DropColumn("dbo.Tags", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
