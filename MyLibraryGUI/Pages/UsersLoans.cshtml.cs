using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibrary.Models;
using System.Text.Json;

namespace MyLibrary.GUI.Pages
{
    public class UsersLoansModel : PageModel
    {
        public IList<Book> Books { get; set; } = default!;
        public void OnGet(int userid)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");
            HttpResponseMessage message = client.GetAsync("api/Books/Loans/" + userid).Result;
            string returnText = message.Content.ReadAsStringAsync().Result;
            Books = JsonSerializer.Deserialize<List<Book>>(returnText);
        }
    }
}

