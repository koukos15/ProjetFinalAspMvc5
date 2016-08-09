namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migre2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produits", "img", c => c.String());
            DropColumn("dbo.Produits", "photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produits", "photo", c => c.Binary());
            DropColumn("dbo.Produits", "img");
        }
    }
}
