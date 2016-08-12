namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class joel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImgPath = c.String(),
                        EstPrincipal = c.Boolean(nullable: false),
                        ProduitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .Index(t => t.ProduitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "ProduitId", "dbo.Produits");
            DropIndex("dbo.Photos", new[] { "ProduitId" });
            DropTable("dbo.Photos");
        }
    }
}
