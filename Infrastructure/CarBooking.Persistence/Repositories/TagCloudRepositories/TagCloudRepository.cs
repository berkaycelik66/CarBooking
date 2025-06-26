using CarBooking.Application.Interfaces.TagCloudInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookingContext _context;

        public TagCloudRepository(CarBookingContext context)
        {
            _context = context;
        }

        public async Task<List<TagCloud>> GetTagCloudsByBlogId(int id)
        {
            return await _context.TagClouds.Where(x => x.BlogID == id).ToListAsync();
        }
    }
}
