using Microsoft.AspNetCore.Mvc;
using MyLibrary.GUI.Models;

namespace MyLibrary.Components
{
    public class ShowLoanLinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var linkClass = new LinkClass();
            linkClass.Text = "Låna";
            linkClass.Url = "/Lend";
            return View("Default", linkClass);
        }
    }
}
