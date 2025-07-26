using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailTabPaneComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(string tabName)
        {
            return View();
        }
    }
}
