using CarBookProject.Application.Feautures.Mediator.Queries.CarPricingQueries;
using CarBookProject.Application.Feautures.Mediator.Results.CarPricingResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _carPricingRepository;

		public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository carPricingRepository)
		{
			_carPricingRepository = carPricingRepository;
		}

		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = await _carPricingRepository.GetCarPricingWithTimePeriod();

			return values.Select(x=>new GetCarPricingWithTimePeriodQueryResult{
			     BrandName=x.BrandName,
				 Model=x.Model,
				 CoverImageUrl=x.CoverImageUrl,
				 HourlyAmount=x.HourlyAmount,
				 DailyAmount=x.DailyAmount,
				 WeeklyAmount=x.WeeklyAmount,
				 MonthlyAmount=x.MonthlyAmount,
			}).ToList();
		}
	}
}
