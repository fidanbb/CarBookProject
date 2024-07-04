using CarBookProject.Application.Feautures.Mediator.Queries.FeatureQueries;
using CarBookProject.Application.Feautures.Mediator.Results.FeatureResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Feautures.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetFeatureQueryResult
            {
                FeatureID = x.FeatureID,
                Name=x.Name

            }).ToList();
        }
    }
}
