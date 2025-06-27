using CarBooking.Application.Features.RepositoryPattern;
using CarBooking.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentRepository.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentRepository.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            _commentRepository.Create(comment);
            return Ok("Yorum Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveComment(int id)
        {
            _commentRepository.Remove(id);
            return Ok("Yorum Silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            _commentRepository.Update(comment);
            return Ok("Yorum Güncellendi");
        }

    }
}
