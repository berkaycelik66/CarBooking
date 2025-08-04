using CarBooking.Application.Interfaces.AppRoleInterfaces;
using CarBooking.Domain.Entities;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.AppRoleRepositories
{
    public class AppRoleRepository : IAppRoleRepository
    {
        private readonly CarBookingContext _context;

        public AppRoleRepository(CarBookingContext context)
        {
            _context = context;
        }

        public async Task<AppRole> GetByFilterAsync(Expression<Func<AppRole, bool>> filter)
        {
            return await _context.AppRoles.Where(filter).FirstOrDefaultAsync();
        }
    }
}
