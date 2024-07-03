using CarBookProject.Application.Feautures.CQRS.Results.BrandResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _reepository;

        public GetBrandQueryHandler(IRepository<Brand> reepository)
        {
            _reepository = reepository;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values=await _reepository.GetAllAsync();

            return values.Select(x =>new GetBrandQueryResult{
                BrandID = x.BrandID,
                Name = x.Name,

            }).ToList();
        }
    }
}
