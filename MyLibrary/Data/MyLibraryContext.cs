using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

	}
}
