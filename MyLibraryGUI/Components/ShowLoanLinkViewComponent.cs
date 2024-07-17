using Microsoft.AspNetCore.Mvc;
using MyLibrary.GUI.Models;

namespace MyLibrary.Components
{
    public class ShowLoanLinkViewComponent : ViewComponent
    {
        //public IViewComponentResult Invoke(InvokeRequest request)
        //{
        //    var linkClass = new LinkClass();
        //    linkClass.Text = "Låna";
        //    linkClass.Url = "/Lend";
        //    if (request != null)
        //    {
        //        linkClass.Bookid = request.BookId;
        //        linkClass.Borrowerid = request.UserId;
        //    }

        //    return View("Default", linkClass);
        //}
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
