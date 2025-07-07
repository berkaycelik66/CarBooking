using CarBooking.Application.Interfaces.StatisticInterfaces;
using CarBooking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Persistence.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookingContext _context;

        public StatisticRepository(CarBookingContext context)
        {
            _context = context;
        }

        public async Task<int> GetAuthorCount()
        {
            return await _context.Authors.CountAsync();
        }

        public async Task<decimal> GetAverageRentPriceForDaily()
        {
            return await _context.CarPricings.Where(x => x.PricingID == _context.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingID).FirstOrDefault()).AverageAsync(x => x.Price);
        }

        public async Task<decimal> GetAverageRentPriceForMonthly()
        {
            return await _context.CarPricings.Where(x => x.PricingID == _context.Pricings.Where(x => x.Name == "Aylık").Select(x => x.PricingID).FirstOrDefault()).AverageAsync(x => x.Price);
        }

        public async Task<decimal> GetAverageRentPriceForWeekly()
        {
            return await _context.CarPricings.Where(x => x.PricingID == _context.Pricings.Where(x => x.Name == "Haftalık").Select(x => x.PricingID).FirstOrDefault()).AverageAsync(x => x.Price);
        }

        public async Task<int> GetBlogCount()
        {
            return await _context.Blogs.CountAsync();
        }

        public async Task<string> GetBlogTitleByMaxBlogComment()
        {
            var values = _context.Comments.GroupBy(x => x.BlogID).
                              Select(y => new
                              {
                                  BlogID = y.Key,
                                  Count = y.Count()
                              }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName = await _context.Blogs.Where(x => x.BlogID == values.BlogID).Select(y => y.Title).FirstOrDefaultAsync();
            return blogName;
        }

        public async Task<int> GetBrandCount()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<string> GetBrandNameByMaxCar()
        {
            var values = await _context.Cars.GroupBy(x => x.BrandID).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefaultAsync();
            string brandName = await _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefaultAsync();
            return brandName;
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMax()
        {
            //Select * From CarPricings where Amount=(Select Max(Amount) From CarPricings where PricingID=3)
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Max(x => x.Price);
            int carId = _context.CarPricings.Where(x => x.Price == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = await _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand!.Name + " " + z.Model).FirstOrDefaultAsync();
            return brandModel;
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Min(x => x.Price);
            int carId = _context.CarPricings.Where(x => x.Price == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = await _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefaultAsync();
            return brandModel;
        }

        public async Task<int> GetCarCount()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<int> GetCarCountByFuelElectric()
        {
            return await _context.Cars.Where(x => x.FuelType == "Elektrik").CountAsync();
        }

        public async Task<int> GetCarCountByTransmissionIsAuto()
        {
            return await _context.Cars.Where(x => x.Transmission == "Otomatik").CountAsync();
        }

        public async Task<int> GetLocationCount()
        {
            return await _context.Locations.CountAsync();
        }
    }
}
