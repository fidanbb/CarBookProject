using CarBookProject.Application.Interfaces.CarIntefaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;
        public CarRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<int> GetCarCount()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<List<Car>> GetCarsListWithBrands()
        {
           return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }

        public async Task<List<Car>> GetLast5CarsWithBrands()
        {
           return await _context.Cars.Include(x => x.Brand)
                                     .OrderByDescending(x => x.CarID)
                                     .Take(5)
                                     .ToListAsync();
        }
    }
}
