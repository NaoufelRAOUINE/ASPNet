namespace DemoWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produit")]
    public partial class Produit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Modele { get; set; }

        [Column(TypeName = "money")]
        public decimal? Prix { get; set; }

        public int? Poids { get; set; }

        public int? idCategorie { get; set; }

        public virtual Categorie Categorie { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
    }
}
