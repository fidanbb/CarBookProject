using CarBookProject.Application.Feautures.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Queries.CarPricingQueries
{
	public class GetCarPricingWithTimePeriodQuery:IRequest<List<GetCarPricingWithTimePeriodQueryResult>>
	{
	}
}
