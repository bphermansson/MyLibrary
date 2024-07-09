using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

// Right click on MyLibrary.Test and select "Debug tests".

namespace MyLibrary.Test
{
	public class UnitTest1 : IDisposable
	{
		private static DbContextOptions<MyLibraryContext> dbContextOptions = new DbContextOptionsBuilder<MyLibraryContext>()
		.UseInMemoryDatabase(databaseName: "LibraryDb")
		.Options;

		MyLibraryContext context;

		public UnitTest1()
		{
			context = new MyLibraryContext(dbContextOptions);
			context.Database.EnsureCreated();
		}
		private void SeedDatabase()
		{
			List<Models.User> mockusers = new List<Models.User>()
			{
				new Models.User()
				{
					Id=1,
					Name="Nils"
				},
				new Models.User()
				{
					Id=2,
					Name="Pelle"
				}
			};
			context.User.AddRange(mockusers);
			context.SaveChanges();
		}

		[Fact]
		public async Task AddNameAndReadItBack()
		{
			//Arrange
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7034/");
			var person = new User() { Name = "Liam Bond" };
			var payload = JsonSerializer.Serialize(person);
			var content = new StringContent(payload, Encoding.UTF8, "application/json");

			//Act
			await using var application = new WebApplicationFactory<MyLibrary.Controllers.UsersController>();
			client = application.CreateClient();
			var response = await client.PostAsync("api/Users", content);
			var res = await client.GetFromJsonAsync<List<User>>("/api/Users");
			var lastUserInDb = res[res.Count-1];

			//Assert
			Assert.Equal("James Bond", lastUserInDb.Name);
		}

		[Fact]
		public async Task GetFirstUserNameFromRealDB()
		{
			// Arrange
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7034/");

			// Act
			await using var application = new WebApplicationFactory<MyLibrary.Controllers.UsersController>();
			client = application.CreateClient();
			User? user = await client.GetFromJsonAsync<User>("api/Users/1");

			// Assert
			Assert.Equal("Patrik", user.Name);
		}

		public void Dispose()
		{
			context.Database.EnsureDeleted();
		}
	}
}
