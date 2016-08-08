namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondemigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produits", "Poids", c => c.Int(nullable: false));
            AddColumn("dbo.Produits", "img", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produits", "img");
            DropColumn("dbo.Produits", "Poids");
        }
    }
}
