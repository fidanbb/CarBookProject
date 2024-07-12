using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;
        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<int> GetAuthorCount()
        {
            var value =await _context.Authors.CountAsync();
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForDaily()
        {
            int id =await _context.Pricings.Where(y => y.Name == "Daily").Select(z => z.PricingID).FirstOrDefaultAsync();
            var value =await _context.CarPricings.Where(w => w.PricingID == id).AverageAsync(x => x.Amount);
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForMonthly()
        {
            int id =await _context.Pricings.Where(y => y.Name == "Monthly").Select(z => z.PricingID).FirstOrDefaultAsync();
            var value =await _context.CarPricings.Where(w => w.PricingID == id).AverageAsync(x => x.Amount);
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForWeekly()
        {

            int id =await _context.Pricings.Where(y => y.Name == "Weekly").Select(z => z.PricingID).FirstOrDefaultAsync();
            var value =await _context.CarPricings.Where(w => w.PricingID == id).AverageAsync(x => x.Amount);
            return value;
        }

        public async Task<int> GetBlogCount()
        {
            var value =await _context.Blogs.CountAsync();
            return value;
        }

        public async Task<string> GetBlogTitleByMaxBlogComment()
        {
            var values =await _context.Comments.GroupBy(x => x.BlogID).
                              Select(y => new
                              {
                                  BlogID = y.Key,
                                  Count = y.Count()
                              }).OrderByDescending(z => z.Count).Take(1).FirstOrDefaultAsync();
            string blogName =await _context.Blogs.Where(x => x.BlogID == values.BlogID).Select(y => y.Title).FirstOrDefaultAsync();
            return blogName;
        }

        public async Task<int> GetBrandCount()
        {
            var value =await _context.Brands.CountAsync();
            return value;
        }

        public async Task<string> GetBrandNameByMaxCar()
        {
            var values =await _context.Cars.GroupBy(x => x.BrandID).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefaultAsync();
            string brandName =await _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefaultAsync();
            return brandName;
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMax()
        {
            int pricingID =await _context.Pricings.Where(x => x.Name == "Daily").Select(y => y.PricingID).FirstOrDefaultAsync();
            decimal amount =await _context.CarPricings.Where(y => y.PricingID == pricingID).MaxAsync(x => x.Amount);
            int carId =await _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefaultAsync();
            string brandModel =await _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefaultAsync();
            return brandModel;
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingID = await _context.Pricings.Where(x => x.Name == "Daily").Select(y => y.PricingID).FirstOrDefaultAsync();
            decimal amount = await _context.CarPricings.Where(y => y.PricingID == pricingID).MinAsync(x => x.Amount);
            int carId = await _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefaultAsync();
            string brandModel = await _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefaultAsync();
            return brandModel;
        }

        public async Task<int> GetCarCount()
        {
            var value =await _context.Cars.CountAsync();
            return value;
        }

        public async Task<int> GetCarCountByFuelElectric()
        {
            var value =await _context.Cars.Where(x => x.Fuel == "Electric").CountAsync();
            return value;
        }

        public async Task<int> GetCarCountByFuelGasolineOrDiesel()
        {
            var value =await _context.Cars.Where(x => x.Fuel == "Gasoline" || x.Fuel == "Diesel").CountAsync();
            return value;
        }

        public async Task<int> GetCarCountByKmSmallerThen1000()
        {
            var value =await _context.Cars.Where(x => x.Km <= 1000).CountAsync();
            return value;
        }

        public async Task<int> GetCarCountByTranmissionIsAuto()
        {
            var value =await _context.Cars.Where(x => x.Transmission == "Automatic").CountAsync();
            return value;
        }

        public async Task<int> GetLocationCount()
        {
            var value =await _context.Locations.CountAsync();
            return value;
        }
    }
}
