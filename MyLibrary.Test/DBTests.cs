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
        [Fact]
        public async Task SearchForABookWithIdThree()
        {
            // Arrange
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");

            // Act
            await using var application = new WebApplicationFactory<MyLibrary.Controllers.BooksController>();
            client = application.CreateClient();
            var book = await client.GetFromJsonAsync<Models.Book>("api/Books/BookById/3");

            // Assert
            Assert.True(book != null);
        }
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
