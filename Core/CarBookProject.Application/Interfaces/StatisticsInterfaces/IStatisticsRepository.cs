using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        Task<int> GetCarCount();
        Task<int> GetLocationCount();
        Task< int >GetAuthorCount();
        Task<int> GetBlogCount();
        Task<int> GetBrandCount();
        Task<decimal> GetAvgRentPriceForDaily();
        Task<decimal> GetAvgRentPriceForWeekly();
        Task<decimal> GetAvgRentPriceForMonthly();
        Task<int> GetCarCountByTranmissionIsAuto();
        Task<string> GetBrandNameByMaxCar();
        Task<string> GetBlogTitleByMaxBlogComment();
        Task<int> GetCarCountByKmSmallerThen1000();
        Task<int> GetCarCountByFuelGasolineOrDiesel();
        Task<int> GetCarCountByFuelElectric();
        Task<string> GetCarBrandAndModelByRentPriceDailyMax();
        Task<string> GetCarBrandAndModelByRentPriceDailyMin();
    }
}
