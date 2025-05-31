using CarBooking.Application.Interfaces.CarPricingInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookingContext _context;

        public CarPricingRepository(CarBookingContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {
            return await _context.CarPricings.Include(x=> x.Car).ThenInclude(x => x.Brand).Include(x => x.Pricing).Where(x => x.PricingID == 2).ToListAsync();
        }
    }
}
