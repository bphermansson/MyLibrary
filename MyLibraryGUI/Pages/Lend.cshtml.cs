using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyLibrary.GUI.Pages
{
    public class LendModel : PageModel
    {
        public void OnGet()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7034/");
            //HttpResponseMessage message = client.GetAsync("api/Books/" + SearchString).Result;
            //string returnText = message.Content.ReadAsStringAsync().Result;
        }
    }
}
