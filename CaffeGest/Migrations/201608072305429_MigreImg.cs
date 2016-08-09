namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigreImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produits", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produits", "Image");
        }
    }
}
