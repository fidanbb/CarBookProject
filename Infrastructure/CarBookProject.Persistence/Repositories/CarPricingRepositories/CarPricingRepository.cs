using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetDailyCarPricingWithCars()
        {
           var values=await _context.CarPricings.Include(x=>x.Car)
                                                .ThenInclude(y=>y.Brand)
                                                .Include(z=>z.Pricing)
                                                .Where(a=>a.PricingID==2)
                                                .ToListAsync();

            return values;
        }

        public async Task<List<CarPricing>> GetLast5DailyCarPricingWithCars()
        {
            var values = await _context.CarPricings.Include(x => x.Car)
                                               .ThenInclude(y => y.Brand)
                                               .Include(z => z.Pricing)
                                               .Where(a => a.PricingID == 2)
                                               .OrderByDescending(x => x.CarID)
                                               .Take(5)
                                               .ToListAsync();

            return values;
        }
    }
}
