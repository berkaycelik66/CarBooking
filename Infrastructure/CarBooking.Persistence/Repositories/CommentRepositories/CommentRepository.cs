using CarBooking.Application.Features.RepositoryPattern;
using CarBooking.Domain.Entities;
using CarBooking.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookingContext _context;

        public CommentRepository(CarBookingContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.Select(x => new Comment
            {
                CommentID = x.CommentID,
                Name = x.Name,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                BlogID = x.BlogID,
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id)!;
        }

        public List<Comment> GetCommentsByBlogId(int id)
        {
            return _context.Set<Comment>().Where(x => x.BlogID == id).ToList();
        }

        public void Remove(int id)
        {
            var value = _context.Comments.Find(id);
            if (value != null)
            {
                _context.Comments.Remove(value);
                _context.SaveChanges();
            }
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }
    }
}
