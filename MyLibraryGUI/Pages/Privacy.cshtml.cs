using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyLibrary.GUI.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel2> _logger;

        public PrivacyModel(ILogger<PrivacyModel2> logger)
        {
           // _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
