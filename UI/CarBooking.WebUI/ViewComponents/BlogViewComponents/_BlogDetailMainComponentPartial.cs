using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
