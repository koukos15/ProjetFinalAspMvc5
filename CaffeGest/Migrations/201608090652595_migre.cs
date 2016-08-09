namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produits", "Poids", c => c.Int(nullable: false));
            DropColumn("dbo.Produits", "Grammage");
            DropColumn("dbo.Produits", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produits", "Image", c => c.String());
            AddColumn("dbo.Produits", "Grammage", c => c.Int(nullable: false));
            DropColumn("dbo.Produits", "Poids");
        }
    }
}
