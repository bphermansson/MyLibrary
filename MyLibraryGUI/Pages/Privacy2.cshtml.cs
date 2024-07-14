using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibrary.Models;
using System.Text.Json;
using System.Xml.Linq;

namespace MyLibrary.GUI.Pages
{
    public class PrivacyModel2 : PageModel
    {
        public IList<Book> Books { get; set; } = default!;
        
        public void OnGet()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");
            HttpResponseMessage message = client.GetAsync("api/Books").Result;
            string returnText = message.Content.ReadAsStringAsync().Result;
            Books = JsonSerializer.Deserialize<List<Book>>(returnText);
        }
    }
}
