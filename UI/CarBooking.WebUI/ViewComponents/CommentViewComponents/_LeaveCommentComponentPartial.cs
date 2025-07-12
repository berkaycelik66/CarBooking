using CarBooking.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.WebUI.ViewComponents.CommentViewComponents
{
    public class _LeaveCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            var model = new CreateCommentDto
            {
                BlogID = id
            };

            return View(model);
        }
    }
}
