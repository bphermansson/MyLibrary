using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
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

            // Act
            await using var application = new WebApplicationFactory<MyLibrary.Controllers.BooksController>();
            client = application.CreateClient();
            var res = await client.GetAsync("api/Books/LoanBook?bookid=2&userid=1");    // Lend book 2
            res = await client.GetAsync("api/Books/ReturnBook?bookid=1");    // Return book 1

            // Assert
            Assert.NotNull(res);
        }
    }
}
