using Microsoft.AspNetCore.Mvc;

namespace ViewComponentDemo.Components
{
    public class ShowNumberViewComponent: ViewComponent
    {

        // Get data to display. Can from a db, api, or as here just a static number.

        public IViewComponentResult Invoke(int count)
        {
            //var model = new List<string>();
            //model.Add("a");
            //model.Add("b");
            if(count == 0)
            {
                count = 1;
            }
            var things = 2 * count;

            //return View("Default", model);
            return View("Default", things);
        }
    }
}
