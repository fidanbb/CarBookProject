using CarBookProject.Application.Feautures.Mediator.Queries.BlogQueries;
using CarBookProject.Application.Feautures.Mediator.Results.BlogResults;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Handlers.BlogHandlers
{
    public class GetBlogAuhtorByBlogIdQueryHandler : IRequestHandler<GetBlogAuhtorByBlogIdQuery, GetBlogAuhtorByBlogIdQueryResult>
    {
        private readonly IBlogRepository _repository;
        public GetBlogAuhtorByBlogIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetBlogAuhtorByBlogIdQueryResult> Handle(GetBlogAuhtorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetBlogAuthorByBlogId(request.Id);
            return new GetBlogAuhtorByBlogIdQueryResult
            {
                AuthorID = value.AuthorID,
                BlogID = value.BlogID,
                AuthorName = value.Author.Name,
                AuthorDescription = value.Author.Description,
                AuthorImageUrl = value.Author.ImageUrl,
            };
        }
    }
}
