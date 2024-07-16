using CarBookProject.Application.Feautures.Mediator.Queries.CarFeatureQueries;
using CarBookProject.Application.Feautures.Mediator.Results.CarFeatureResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarFeatureInterfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _carFeatureRepository.GetCarFeaturesByCarID(request.Id);

            return values.Select(x=>new GetCarFeatureByCarIdQueryResult
            {
                FeatureID = x.FeatureID,
                CarFeatureID = x.CarFeatureID,
                CarID=x.CarID,
                FeatureName=x.Feature.Name,
                Available=x.Available
            }).ToList();

        }
    }
}
