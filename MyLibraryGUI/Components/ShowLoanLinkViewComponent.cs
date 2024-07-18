using Microsoft.AspNetCore.Mvc;
using MyLibrary.GUI.Models;

namespace MyLibrary.Components
{
    public class ShowLoanLinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(LoanClass loanClass)
        {
            var linkClass = new LinkClass();
            linkClass.Text = "Låna";
            linkClass.Url = "/Lend";
            linkClass.Bookid = loanClass.BookId;
            linkClass.Borrowerid = loanClass.UserId;
            return View("Default", linkClass);
        }
    }
}
