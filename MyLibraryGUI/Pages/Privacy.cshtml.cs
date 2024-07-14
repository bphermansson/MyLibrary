using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyLibrary.GUI.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<ListAllModel> _logger;

        public PrivacyModel(ILogger<ListAllModel> logger)
        {
           // _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
