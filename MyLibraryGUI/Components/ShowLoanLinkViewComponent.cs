using Microsoft.AspNetCore.Mvc;
using MyLibrary.GUI.Models;

namespace MyLibrary.Components
{
    public class ShowLoanLinkViewComponent : ViewComponent
    {

        // Get data to display. Can from a db, api, or as here just a static number.

        public IViewComponentResult Invoke()
        {
            var linkClass = new LinkClass();
            linkClass.Text = "Låna";
            linkClass.Url = "/Lend";
            //List<string> link = new List<string> { "Låna", "/Lend" };
            return View("Default", linkClass);
        }
    }
}
