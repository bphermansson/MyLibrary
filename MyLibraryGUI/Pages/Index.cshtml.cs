using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using MyLibrary.Models;

namespace MyLibraryGUI.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        //[Required]
        //[BindProperty]
        //public string SearchString { get; set; }
        public List<Book> bookList { get; set; }
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        [TempData]
        public string SearchString { get; set; }

        //public void OnGet()
        //{
        //if(SearchString != null)
        //{
        //    return RedirectToPage("/SearchResult");
        //}
        //return Redirect("~/");


        //HttpClient client = new HttpClient();
        //client.BaseAddress = new Uri("https://localhost:7034/");
        //HttpResponseMessage message = client.GetAsync("api/Users").Result;
        //string returnText = message.Content.ReadAsStringAsync().Result;

        //message = client.GetAsync("api/Books").Result;
        //returnText = message.Content.ReadAsStringAsync().Result;

        //List<Book> bookList = new List<Book>();
        //bookList =
        //    JsonSerializer.Deserialize<List<Book>>(returnText);
        //}

        public void OnGet()
        {
  
        }

        public IActionResult OnPost()
        {
            SearchString = Request.Form["SearchString"];
            //SearchString = "Incorrect password";

            return RedirectToPage("/SearchResult");
        }
    }
}
