namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migre1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produits", "photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produits", "photo");
        }
    }
}
