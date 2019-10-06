using Code_First_PostgreSQL_Web_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_First_PostgreSQL_Web_Api.Dal
{
    public class BookDbContext : DbContext
    {
        //ConnectionString to Database
        public BookDbContext(DbContextOptions<BookDbContext> options)
         : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBiography> AuthorBiographies { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasIndex(x => x.FirstName);
            modelBuilder.Entity<AuthorBiography>().HasIndex(r => r.Nationality);
            modelBuilder.Entity<Book>().HasIndex(t => t.Title);
            base.OnModelCreating(modelBuilder);
        }
    }
}