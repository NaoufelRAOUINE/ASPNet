namespace DemoWebMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EDM : DbContext
    {
        public EDM()
            : base("name=EDM")
        {
        }

        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>()
                .Property(e => e.Nom)
                .IsFixedLength();

            modelBuilder.Entity<Categorie>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Categorie>()
                .HasMany(e => e.Produits)
                .WithOptional(e => e.Categorie)
                .HasForeignKey(e => e.idCategorie);

            modelBuilder.Entity<Produit>()
                .Property(e => e.Modele)
                .IsFixedLength();

            modelBuilder.Entity<Produit>()
                .Property(e => e.Prix)
                .HasPrecision(19, 4);
        }

        public System.Data.Entity.DbSet<DemoWebMVC.Models.Detail> Details { get; set; }

        public System.Data.Entity.DbSet<DemoWebMVC.Models.Commande> Commandes { get; set; }
    }
}
