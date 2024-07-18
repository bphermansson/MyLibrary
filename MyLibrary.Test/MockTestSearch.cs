using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using System.Collections.Generic;

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

		[Fact]
		public void CheckTitleOfBookTwo()
		{
			// Arrange
			SeedDatabase();
			Models.Book book;

			// Act
			//Do not use id's, they are unpredictable (changes between runs).
			//book = context.Book.Find(3);
			book = context.Book.Where(s => s.Author == "Stephen King").FirstOrDefault();

			// Assert
			Assert.Equal("Det", book.Name);
		}
		[Fact]
		public void CheckAuthorOfBookThree()
		{
			SeedDatabase();
			Models.Book book;
			book = context.Book.Where(s => s.Name == "Trumslagarpojken").FirstOrDefault();

			Assert.Equal("Anders Johansson", book.Author);
		}
		private void SeedDatabase()
		{

			List<Models.Book> mockbooks = new List<Models.Book>()
			{
				new Models.Book()
				{
					//Id=1,
					Name="Röda rummet",
					Author="August Strindberg"
				},
				new Models.Book()
				{
					//Id=2,
					Name="Det",
					Author="Stephen King"
				},
				new Models.Book()
				{
					//Id=3,
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
