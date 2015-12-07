namespace JoinMeLive.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class participantcount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discussions", "ParticipantCount", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Discussions", "ParticipantCount");
        }
    }
}
