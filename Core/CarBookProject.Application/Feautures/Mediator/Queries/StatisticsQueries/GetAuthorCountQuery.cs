using CarBookProject.Application.Feautures.Mediator.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarBookProject.Application.Feautures.Mediator.Queries.StatisticsQueries
{
    public class GetAuthorCountQuery:IRequest<GetAuthorCountQueryResult>
    {
    }
}
