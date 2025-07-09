using CarBooking.Application.Interfaces.RentACarInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookingContext _context;

        public RentACarRepository(CarBookingContext context)
        {
            _context = context;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            return await _context.RentACars.Where(filter).ToListAsync();
        }
    }
}
