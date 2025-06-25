using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.CommentViewComponents
{
    public class _LeaveCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
