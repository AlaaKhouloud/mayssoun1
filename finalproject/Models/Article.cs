using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalproject.Models
{
    public class Article
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int numArticle { get; set; }
        public string designation { get; set; }

        public double prixU { get; set; }

        public int stock { get; set; }

        public string photo { get; set; }

        public string refcategorie { get; set; }

        public virtual Categorie categorie{ get; set; }

    }
}