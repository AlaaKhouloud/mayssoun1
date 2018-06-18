using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalproject.Models
{
    public class Panier
    {
        public Panier()
        {
            this.commandes = new HashSet<LigneCommande>();
        }
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int numCmd { get; set; }
        public string dateCmd { get; set; }
        public int idClient { get; set; }
        public virtual Client client { get; set; }
        public ICollection<LigneCommande>  commandes { get; set; }
    }
}