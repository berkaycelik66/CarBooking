using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailAboutAuthorComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
