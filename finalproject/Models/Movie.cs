using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalproject.Models
{
    public class Movie
    {
        public Movie()
        {
            this.actors = new HashSet<Actor>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int idMovie { get; set; }
        public string title { get; set; }
        public int idActor { get; set; }
        public virtual ICollection<Actor> actors { get; set; }
    }
}
