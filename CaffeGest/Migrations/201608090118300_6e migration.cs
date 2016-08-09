namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6emigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ApplicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Produits", "PU", c => c.Double(nullable: false));
            CreateIndex("dbo.Users", "ApplicationUserId");
            AddForeignKey("dbo.Users", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Produits", "PU", c => c.Double());
            DropColumn("dbo.Users", "ApplicationUserId");
        }
    }
}
