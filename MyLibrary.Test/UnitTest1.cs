using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using MyLibrary.Models;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Runtime.ConstrainedExecution;
using System.Net.Http;

// Right click on MyLibry.Test and select "Debug tests".

namespace MyLibrary.Test
{
	public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
	{
		[Fact]
		public async Task GetFirstUserName()
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
		[Fact]
		public async Task AddNameAndReadItBack()
		{
			//Arrange
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7034/");
			await using var application = new WebApplicationFactory<MyLibrary.Controllers.UsersController>();
			client = application.CreateClient();

			var person = new User() { Name = "James Bond" };
			var payload = JsonSerializer.Serialize(person);
			var content = new StringContent(payload, Encoding.UTF8, "application/json");

			//Act
			var response = await client.PostAsync("api/Users", content);
			var res = await client.GetFromJsonAsync<List<User>>("/api/Users");
			var lastUserInDb = res[res.Count-1];

			//Assert
			Assert.Equal(person.Name, lastUserInDb.Name);
		}
	}
}
