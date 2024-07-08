using CarBookProject.Application.Feautures.Mediator.Queries.CarPricingQueries;
using CarBookProject.Application.Feautures.Mediator.Results.CarPricingResults;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Handlers.CarPricingHandlers
{
    public class GetLast5DailyCarPricingWithCarsQueryHandler : IRequestHandler<GetLast5DailyCarPricingWithCarsQuery, List<GetLast5DailyCarPricingWithCarsQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetLast5DailyCarPricingWithCarsQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetLast5DailyCarPricingWithCarsQueryResult>> Handle(GetLast5DailyCarPricingWithCarsQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.GetLast5DailyCarPricingWithCars();

            return values.Select(x => new GetLast5DailyCarPricingWithCarsQueryResult
            {
                Amount = x.Amount,
                CarPricingId = x.CarPricingID,
                Brand = x.Car.Brand.Name,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                CarId = x.CarID
            }).ToList();
        }
    }
}
