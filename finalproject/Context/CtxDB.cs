namespace finalproject.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using finalproject.Models;

    public partial class CtxDB : DbContext
    {
        public CtxDB()
            : base("name=CtxDB")
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<LigneCommande> LignesCmd { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Countries> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
