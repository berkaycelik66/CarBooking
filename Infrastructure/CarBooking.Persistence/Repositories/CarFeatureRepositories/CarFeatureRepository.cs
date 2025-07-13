using CarBooking.Application.Interfaces.CarFeatureInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookingContext _context;

        public CarFeatureRepository(CarBookingContext context)
        {
            _context = context;
        }

        public async Task ChangeCarFeaturePresentToFalse(int id)
        {
            var value = await _context.CarFeatures.Where(cf => cf.CarFeatureID == id).FirstOrDefaultAsync();
            if (value != null)
            {
                value.IsPresent = false;
                _context.CarFeatures.Update(value);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ChangeCarFeaturePresentToTrue(int id)
        {
            var value = await _context.CarFeatures.Where(cf => cf.CarFeatureID == id).FirstOrDefaultAsync();
            if (value != null)
            {
                value.IsPresent = true;
                _context.CarFeatures.Update(value);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<CarFeature>> GetCarFeaturesByCarId(int id)
        {
            return _context.CarFeatures.Where(cf => cf.CarID == id).Include(x => x.Feature).ToListAsync();
        }
    }
}
