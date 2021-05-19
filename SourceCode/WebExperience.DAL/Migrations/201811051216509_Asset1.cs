namespace WebExperience.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asset1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Asset");
            DropColumn("dbo.Asset", "Id");
            AddColumn("dbo.Asset", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Asset", "Id");
            DropColumn("dbo.Asset", "AssetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Asset", "AssetId", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.Asset");
            AlterColumn("dbo.Asset", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Asset", "Id");
        }
    }
}
