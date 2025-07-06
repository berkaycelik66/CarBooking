using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminStatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
