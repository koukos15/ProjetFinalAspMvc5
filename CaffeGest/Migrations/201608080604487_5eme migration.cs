namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5ememigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produits", "PU", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produits", "PU", c => c.Double(nullable: false));
        }
    }
}
