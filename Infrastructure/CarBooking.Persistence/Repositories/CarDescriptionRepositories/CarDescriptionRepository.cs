using CarBooking.Application.Interfaces.CarDescriptionInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookingContext _context;

        public CarDescriptionRepository(CarBookingContext context)
        {
            _context = context;
        }

        public async Task<CarDescription> GetCarDescriptionByCarId(int carId)
        {
            return await _context.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefaultAsync();
        }
    }
}
