using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalproject.Models
{
    public class Actor
    {
        public Actor()
        {
            this.movies = new HashSet<Movie>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int idActor { get; set; }
        public string name { get; set; }
         
        public virtual ICollection<Movie> movies { get; set; }
    }
}