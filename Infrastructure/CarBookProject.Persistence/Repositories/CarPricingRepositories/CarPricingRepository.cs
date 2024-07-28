using CarBookProject.Application.Dtos;
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

        public async Task AddRange(List<CarPricing> carPricings)
        {
           await _context.CarPricings.AddRangeAsync(carPricings);
		   await _context.SaveChangesAsync();
        }

        public async Task<List<CarPricingDto>> GetCarPricingWithTimePeriod()
		{
			var carPricingData = await _context.Cars
	                                                .Include(c => c.Brand)
	                                                .Include(c => c.CarPricings)
	                                                .ThenInclude(cp => cp.Pricing)
	                                                .Select(c => new
	                                                {
		                                               c.Brand.Name,
		                                               c.Model,
		                                               c.CoverImageUrl,

		                                                 HourlyAmount = c.CarPricings
			                                                      .Where(cp => cp.Pricing.Name == "Hourly")
			                                                      .Select(cp => (decimal?)cp.Amount)
			                                                      .FirstOrDefault(),

		                                                 DailyAmount = c.CarPricings
			                                                      .Where(cp => cp.Pricing.Name == "Daily")
			                                                      .Select(cp => (decimal?)cp.Amount)
			                                                      .FirstOrDefault(),

		                                                 WeeklyAmount = c.CarPricings
		                                                    	  .Where(cp => cp.Pricing.Name == "Weekly")
			                                                      .Select(cp => (decimal?)cp.Amount)
			                                                      .FirstOrDefault(),

														MonthlyAmount = c.CarPricings
																  .Where(cp => cp.Pricing.Name == "Monthly")
																  .Select(cp => (decimal?)cp.Amount)
																  .FirstOrDefault()
													})
	                                                .ToListAsync();

			var carPricings = carPricingData.Select(c => new CarPricingDto
			{
				BrandName = c.Name,
				Model = c.Model,
				CoverImageUrl = c.CoverImageUrl,
				HourlyAmount = c.HourlyAmount,
				DailyAmount = c.DailyAmount,
				WeeklyAmount = c.WeeklyAmount,
				MonthlyAmount = c.MonthlyAmount,
			}).ToList();

			return carPricings;
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
