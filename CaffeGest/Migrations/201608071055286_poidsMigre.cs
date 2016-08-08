namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poidsMigre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produits", "Grammage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produits", "Grammage");
        }
    }
}
