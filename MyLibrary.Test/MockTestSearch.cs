using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock.AutoMock.Ninject.Activation;

namespace MyLibrary.Test
{
	public class MockTestSearch : IDisposable
	{
		private static DbContextOptions<MyLibraryContext> dbContextOptions = new DbContextOptionsBuilder<MyLibraryContext>()
			.UseInMemoryDatabase(databaseName: "LibraryDb")
			.Options;

		MyLibraryContext context;
		public MockTestSearch()
		{
			context = new MyLibraryContext(dbContextOptions);
			context.Database.EnsureCreated();
		}
		private void SeedDatabase()
		{
			List<Models.Book> mockbooks = new List<Models.Book>()
			{
				new Models.Book()
				{
					Id=1,
					Name="Röda rummet",
					Author="August Strindberg"
				},
				new Models.Book()
				{
					Id=2,
					Name="Det",
					Author="Stephen King"
				},
				new Models.Book()
				{
					Id=3,
					Name="Trumslagarpojken",
					Author="Anders Johansson"
				}

			};
			context.Book.AddRange(mockbooks);
			context.SaveChanges();
		}
		public void Dispose()
		{
			context.Database.EnsureDeleted();
		}
	}
}
