using CarBookProject.Application.Feautures.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Queries.BlogQueries
{
    public class GetBlogAuhtorByBlogIdQuery : IRequest<GetBlogAuhtorByBlogIdQueryResult>
    {
        public int Id { get; set; }
        public GetBlogAuhtorByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
