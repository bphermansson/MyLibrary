using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibrary.Models;
using System.Text.Json;

namespace MyLibrary.GUI.Pages
{
    public class SearchModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        //public string? SearchString { get; set; }
        public IList<Book> Books { get; set; } = default!;

        public void OnGet()
        {
            var SearchString = TempData["SearchString"];
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");
            HttpResponseMessage message = client.GetAsync("api/Books/"+SearchString).Result;
            string returnText = message.Content.ReadAsStringAsync().Result;
            Books = JsonSerializer.Deserialize<List<Book>>(returnText);
        }
    }
}
