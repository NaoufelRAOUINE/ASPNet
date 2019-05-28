using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoWebMVC.Models
{
    [Table("Details")]
    public class Detail
    {
        [Key]
        public int Id { get; set; }

        public virtual int IdCommande { get; set; }
        [ForeignKey("IdCommande")]
        public Commande Commande { get; set; }

        public virtual int IdProduit { get; set; }
        [ForeignKey("IdProduit")]
        public Produit Produit { get; set; }

        public int Quantite { get; set; }
    }
}