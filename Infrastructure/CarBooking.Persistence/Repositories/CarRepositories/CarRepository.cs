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

        public async Task<Car> GetCarByIdWithBrand(int id)
        {
            return await _context.Cars.Include(x => x.Brand).Where(x => x.CarID == id).FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetLast5CarsWithBrands()
        {
            return await _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToListAsync();
        }

        public async Task<List<Car>> GetCarCountByBrand()
        {
            return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }
        public async Task<Car> GetCarDetailByIdWithBrand(int id)
        {
            return await _context.Cars.Include(x => x.Brand).Where(x => x.CarID == id).FirstOrDefaultAsync();
        }
    }
}
