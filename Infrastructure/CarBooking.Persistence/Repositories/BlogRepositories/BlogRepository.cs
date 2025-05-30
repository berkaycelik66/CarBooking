using CarBooking.Application.Interfaces.BlogInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookingContext _context;

        public BlogRepository(CarBookingContext context)
        {
            _context = context;
        }

        public Task<List<Blog>> GetLast3BlogsWithAuthors()
        {
            return _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToListAsync();
        }
    }
}
