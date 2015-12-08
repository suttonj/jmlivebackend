namespace JoinMeLive.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreviewImageInDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discussions", "PreviewImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Discussions", "PreviewImageUrl");
        }
    }
}
