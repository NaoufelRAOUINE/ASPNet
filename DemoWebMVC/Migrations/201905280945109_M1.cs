namespace DemoWebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCommande = c.Int(nullable: false),
                        IdProduit = c.Int(nullable: false),
                        Quantite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commandes", t => t.IdCommande, cascadeDelete: true)
                .ForeignKey("dbo.Produit", t => t.IdProduit, cascadeDelete: true)
                .Index(t => t.IdCommande)
                .Index(t => t.IdProduit);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IdClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "IdProduit", "dbo.Produit");
            DropForeignKey("dbo.Details", "IdCommande", "dbo.Commandes");
            DropIndex("dbo.Details", new[] { "IdProduit" });
            DropIndex("dbo.Details", new[] { "IdCommande" });
            DropTable("dbo.Commandes");
            DropTable("dbo.Details");
        }
    }
}
