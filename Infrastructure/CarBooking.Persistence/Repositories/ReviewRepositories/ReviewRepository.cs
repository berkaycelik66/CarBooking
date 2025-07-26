using CarBooking.Application.Interfaces.ReviewInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarBookingContext _context;

        public ReviewRepository(CarBookingContext context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetReviewsByCarId(int carId)
        {
            return await _context.Reviews.Where(r => r.CarID == carId).ToListAsync();
        }
    }
}
