using CarBooking.Application.Interfaces.CarInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookingContext _context;

        public CarRepository(CarBookingContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarListWithBrands()
        {
            return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }

        public async Task<List<Car>> GetLast5CarsWithBrands()
        {
            return await _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToListAsync();
        }
    }
}
