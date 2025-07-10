using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarListWithBrands();
        Task<Car> GetCarByIdWithBrand(int id);
        Task<List<Car>> GetLast5CarsWithBrands();
    }
}
