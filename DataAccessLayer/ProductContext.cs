using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductRough.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductRough.ContextFolder
{
    public class ProductContext:DbContext
    {
        public ProductContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                /* .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);*/
                IConfigurationRoot config = builder.Build();
                var connectionString = @"Data Source=XIPL9375\SQLEXPRESS;Initial Catalog=FINAL_Amazon_API;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public ProductContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Operator>().HasIndex(u => u.Email)
               .IsUnique();

            base.OnModelCreating(builder);
           // builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //builder.Entity<Cart>().HasRequired(p => p.Blog);

            //        builder.Entity<Cart>()
            //.HasRequired(c => c.Stage)
            //.WithMany()
            //.WillCascadeOnDelete(false);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItems> ProductItemes{ get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
