namespace WebExperience.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asset",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetId = c.Guid(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 100),
                        MimeType = c.String(maxLength: 100),
                        Email = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Asset");
        }
    }
}
