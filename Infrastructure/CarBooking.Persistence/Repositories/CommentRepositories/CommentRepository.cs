using CarBooking.Application.Features.RepositoryPattern;
using CarBooking.Application.Interfaces.CommentInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookingContext _context;

        public CommentRepository(CarBookingContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetCommentsByBlogId(int id)
        {
            return await _context.Comments.Where(x => x.BlogID == id).ToListAsync();
        }
    }
}
