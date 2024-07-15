using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

// Right click on MyLibrary.Test and select "Debug tests".

namespace MyLibrary.Test
{
	public class DBTests
	{
		//private static DbContextOptions<MyLibraryContext> dbContextOptions = new DbContextOptionsBuilder<MyLibraryContext>()
		//.UseInMemoryDatabase(databaseName: "LibraryDb")
		//.Options;

		//MyLibraryContext context;

		//public DBTests()
		//{
		//	context = new MyLibraryContext(dbContextOptions);
		//	context.Database.EnsureCreated();
		//}
		//private void SeedDatabase()
		//{
		//	List<Models.User> mockusers = new List<Models.User>()
		//	{
		//		new Models.User()
		//		{
		//			Id=1,
		//			Name="Nils"
		//		},
		//		new Models.User()
		//		{
		//			Id=2,
		//			Name="Pelle"
		//		}
		//	};
		//	context.User.AddRange(mockusers);
		//	context.SaveChanges();
		//}

		//[Fact]
		//public async Task AddNameAndReadItBack()
		//{
		//	//Arrange
		//	HttpClient client = new HttpClient();
		//	client.BaseAddress = new Uri("https://localhost:7034/");
		//	var person = new User() { Name = "James Bond" };
		//	var payload = JsonSerializer.Serialize(person);
		//	var content = new StringContent(payload, Encoding.UTF8, "application/json");

		//	//Act
		//	await using var application = new WebApplicationFactory<MyLibrary.Controllers.UsersController>();
		//	client = application.CreateClient();
		//	var response = await client.PostAsync("api/Users", content);
		//	var res = await client.GetFromJsonAsync<List<User>>("/api/Users");
		//	var lastUserInDb = res[res.Count-1];

		//	//Assert
		//	Assert.Equal("James Bond", lastUserInDb.Name);
		//}

		//[Fact]
		//public async Task GetFirstUserNameFromRealDB()
		//{
		//	// Arrange
		//	HttpClient client = new HttpClient();
		//	client.BaseAddress = new Uri("https://localhost:7034/");

		//	// Act
		//	await using var application = new WebApplicationFactory<MyLibrary.Controllers.UsersController>();
		//	client = application.CreateClient();
		//	User? user = await client.GetFromJsonAsync<User>("api/Users/1");

		//	// Assert
		//	Assert.Equal("Patrik", user.Name);
		//}
		[Fact]
		public async Task SearchForABookWithKingInTheTitleOrInTheAuthorsName()
		{
			// Arrange
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7034/");

            // Act
            await using var application = new WebApplicationFactory<MyLibrary.Controllers.BooksController>();
            client = application.CreateClient();
            var allBooks = await client.GetFromJsonAsync<List<Models.Book>>("api/Books/King");

            // Assert
            Assert.NotEmpty(allBooks);
			}
        [Fact]
        public async Task SearchForABookWithAuthorAndersJohansson()
        {
            // Arrange
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");

            // Act
            await using var application = new WebApplicationFactory<MyLibrary.Controllers.BooksController>();
            client = application.CreateClient();
            var allBooks = await client.GetFromJsonAsync<List<Models.Book>>("api/Books/Anders Johansson");

            // Assert
            Assert.NotEmpty(allBooks);
        }
        [Fact]
        public async Task CheckThatStephenKingWroteDet()
        {
            // Arrange
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");

            // Act
            await using var application = new WebApplicationFactory<MyLibrary.Controllers.BooksController>();
            client = application.CreateClient();
            var allBooks = await client.GetFromJsonAsync<List<Models.Book>>("api/Books/Det");

            // Assert
            Assert.Equal("Stephen King", allBooks[0].Author);
        }
        [Fact]
        public async Task WhatHappendsIfTheBookDoesntExists()
        {
            // Arrange
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");

            // Act
            await using var application = new WebApplicationFactory<MyLibrary.Controllers.BooksController>();
            client = application.CreateClient();
            var allBooks = await client.GetFromJsonAsync<List<Models.Book>>("api/Books/impossiblebooktitle");

            // Assert
            Assert.Empty(allBooks);
        }
    }
}
