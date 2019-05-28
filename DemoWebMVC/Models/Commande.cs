using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoWebMVC.Models
{
    [Table("Commandes")]
    public class Commande
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int IdClient { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
    }
}