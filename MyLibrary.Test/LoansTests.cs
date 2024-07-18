using Microsoft.AspNetCore.Mvc.Testing;
using MyLibrary.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace MyLibrary.Test
{
    public class LoansTests
    {
        [Fact]
        public async Task HowManyBooksHaveAUserLend()
        // Can return zero or more, but not null.
        {
            // Arrange
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");

            // Act
            await using var application = new WebApplicationFactory<MyLibrary.Controllers.BooksController>();
            client = application.CreateClient();
            var allBooks = await client.GetFromJsonAsync<List<Models.Book>>("api/Books/Loans/1");

            // Assert
            Assert.NotNull(allBooks);
        }
        [Fact]
        public async Task LoanABook()
        {
            // Arrange
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");

            // Act
            await using var application = new WebApplicationFactory<MyLibrary.Controllers.BooksController>();
            client = application.CreateClient();
            var res = await client.GetAsync("api/Books/LoanBook/1/1");
            
            // Assert
            Assert.Equal(res.IsSuccessStatusCode, true);
        }

        [Fact]
        public async Task CheckWhatBooksAUserhasLoaned()
        {
            // Arrange
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");
            await using var application = new WebApplicationFactory<MyLibrary.Controllers.BooksController>();
            client = application.CreateClient();
            var res = await client.GetAsync("api/Books/LoanBook/1/99");

            // Act
            res = await client.GetAsync("api/Books/Loans/99");

            // Assert
            Assert.Equal(res.IsSuccessStatusCode, true);
        }

        [Fact]
        public async Task TryingToLendALoanedOutBook()
        {
            // Can this be tested?
            // Arrange
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");

            // Act
            await using var application = new WebApplicationFactory<MyLibrary.Controllers.BooksController>();
            client = application.CreateClient();
            var allBooks = await client.GetFromJsonAsync<List<Models.Book>>("api/Books/LoanedOutBooks");

            // Assert
        }
    }
}