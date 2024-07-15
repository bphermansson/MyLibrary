using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace MyLibrary.Test
{
    public class LoansTests
    {
        [Fact]
        public async Task HowManyBooksHaveAUserLend()
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
    }
}
