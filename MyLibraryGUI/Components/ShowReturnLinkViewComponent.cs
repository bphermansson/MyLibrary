using Microsoft.AspNetCore.Mvc;
using MyLibrary.GUI.Models;

namespace MyLibrary.Components
{
    public class ShowReturnLinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(LoanClass loanClass)
        {
            var linkClass = new LinkClass();
            linkClass.Text = "Lämna tillbaka";
            linkClass.Url = "/Return";
            linkClass.Bookid = loanClass.BookId;
            return View("Default", linkClass);
        }
    }
}
