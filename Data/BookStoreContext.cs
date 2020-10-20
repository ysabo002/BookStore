using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Book> Books { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Buyer> Buyers { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ShoppingCart> Carts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Review> Reviews { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Card> Cards { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Address> Addresses { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<SaveForLater> SaveForLater { get; set; }

        //overrriding the nam of the classes into singular 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Buyer>().ToTable("Buyer");
            modelBuilder.Entity<ShoppingCart>().ToTable("ShoppingCart");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Card>().ToTable("Card");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<SaveForLater>().ToTable("SaveForLater");

            modelBuilder.Entity<BookShoppingCart>()
            .HasKey(t => new { t.BookID, t.ShoppingCartID });  //relationship many to many


            modelBuilder.Entity<BookBuyer>()
            .HasKey(t => new { t.BookID, t.BuyerID });


            modelBuilder.Entity<BookSaveForLater>()
            .HasKey(t => new { t.BookID, t.SaveForLaterID });











        }
    }
}
