using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Top10Words.DAL.Entities;

namespace Top10Words.DAL.EFCore
{
    public class Top10WordsContext : DbContext, ITop10WordsContext
    {
        public DbSet<Book> Books { get; set; }

        public Top10WordsContext(DbContextOptions<Top10WordsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        // use of Fluent API
        {
            modelBuilder.Entity<Book>().Property(b => b.BookText).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.YearOfPublishing).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.AuthorName).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.FileName).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.BookId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().HasKey(b => new { b.BookId });

            modelBuilder.Entity<Book>().HasData(new { BookId = 1, BookText = "test test", AuthorName = "author name", FileName = "Bible", YearOfPublishing = 2009 },
                new { BookId = 2, BookText = "test test", AuthorName = "Bob", FileName = "2", YearOfPublishing = 2011 });
        }
    }
}
