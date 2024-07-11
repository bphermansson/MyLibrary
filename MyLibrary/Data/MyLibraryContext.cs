using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;

namespace MyLibrary.Data
{
    public class MyLibraryContext : DbContext
    {
		public MyLibraryContext() { }

		public MyLibraryContext (DbContextOptions<MyLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<MyLibrary.Models.User> User { get; set; } = default!;
		public DbSet<MyLibrary.Models.Book> Book { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Name = "Det",
                    Author= "Stephen King"
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 2,
                    Name = "Trumslagarpojken",
                    Author = "Anders Johansson"
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 3,
                    Name = "Normandie",
                    Author = "Anthony Beevor"
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 4,
                    Name = "Det",
                    Author = "Stephen King"
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 5,
                    Name = "I väntan på Godot",
                    Author = "Samuel Becket"
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 6,
                    Name = "Röda rummet",
                    Author = "August Strindberg"
                }
            );
        }
        }
}
