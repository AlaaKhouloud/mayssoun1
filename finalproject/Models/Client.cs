using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalproject.Models
{
    public class Client
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int numClient { get; set; }
        public string login { get; set; }
        public string motPasse { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string ville { get; set; }
        public string tel { get; set; }
        public int idCountry { get; set; } 
        public virtual Countries countrie { get; set; }

    }
}