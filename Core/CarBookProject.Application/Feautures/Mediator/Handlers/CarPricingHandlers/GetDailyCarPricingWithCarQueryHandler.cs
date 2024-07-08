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
    public class GetDailyCarPricingWithCarQueryHandler : IRequestHandler<GetDailyCarPricingWithCarQuery, List<GetDailyCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetDailyCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetDailyCarPricingWithCarQueryResult>> Handle(GetDailyCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.GetDailyCarPricingWithCars();

            return values.Select(x=>new GetDailyCarPricingWithCarQueryResult
            {
                Amount = x.Amount,
                CarPricingId=x.CarPricingID,
                Brand=x.Car.Brand.Name,
                CoverImageUrl=x.Car.CoverImageUrl,
                Model=x.Car.Model,
                CarId=x.CarID
            }).ToList();
        }
    }
}
