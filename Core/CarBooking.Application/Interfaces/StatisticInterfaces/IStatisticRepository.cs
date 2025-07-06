using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Interfaces.StatisticInterfaces
{
    public interface IStatisticRepository
    {
        Task<int> GetCarCount();
        Task<int> GetLocationCount();
        Task<int> GetAuthorCount();
        Task<int> GetBlogCount();
        Task<int> GetBrandCount();
        Task<decimal> GetAverageRentPriceForDaily();
        Task<decimal> GetAverageRentPriceForWeekly();
        Task<decimal> GetAverageRentPriceForMonthly();
        Task<int> GetCarCountByTransmissionIsAuto();
        Task<int> GetCarCountByFuelElectric();
        Task<string> GetBrandNameByMaxCar();
        Task<string> GetBlogTitleByMaxBlogComment();
        Task<string> GetCarBrandAndModelByRentPriceDailyMax();
        Task<string> GetCarBrandAndModelByRentPriceDailyMin();
    }
}
