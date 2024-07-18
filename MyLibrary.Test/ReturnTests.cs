using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Test
{
    public class ReturnTests
    {
        [Fact]
        public async Task ReturnABook()
        {
            // Arrange
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");
            await using var application = new WebApplicationFactory<MyLibrary.Controllers.BooksController>();
            client = application.CreateClient();
            var res = await client.GetAsync("api/Books/LoanBook/2/1");    // Lend book 2
                                                                          
            // Act
            res = await client.GetAsync("api/Books/ReturnBook/2");    // Return book 2

            var book = await client.GetFromJsonAsync<Models.Book>("api/Books/BookById/2");
            // Assert
            Assert.Equal(0, book.BorrowerId);
        }
    }
}
