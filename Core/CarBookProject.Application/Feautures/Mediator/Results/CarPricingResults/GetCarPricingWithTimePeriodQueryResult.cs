using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Results.CarPricingResults
{
	public class GetCarPricingWithTimePeriodQueryResult
	{
		public string BrandName { get; set; }
		public string Model { get; set; }
		public decimal? HourlyAmount { get; set; }
		public decimal? DailyAmount { get; set; }
		public decimal? WeeklyAmount { get; set; }
		public decimal? MonthlyAmount { get; set; }
		public string CoverImageUrl { get; set; }
	}
}
