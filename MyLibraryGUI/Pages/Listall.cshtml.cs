using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using MyLibrary.Models;

namespace MyLibrary.GUI.Pages
{
    public class ListAllModel : PageModel
    {
        public List<Book> bookList = new List<Book>();
       // public IList<Book> Book { get => book; set => book = value; }

        public void OnGet()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");
            HttpResponseMessage message = client.GetAsync("api/Users").Result;
            string returnText = message.Content.ReadAsStringAsync().Result;

            message = client.GetAsync("api/Books").Result;
            returnText = message.Content.ReadAsStringAsync().Result;

            List<Book> bookList = new List<Book>();
            bookList =
                JsonSerializer.Deserialize<List<Book>>(returnText);
        }
    }
}
