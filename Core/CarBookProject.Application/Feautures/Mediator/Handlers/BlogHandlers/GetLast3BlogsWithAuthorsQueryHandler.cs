﻿using CarBookProject.Application.Feautures.Mediator.Queries.BlogQueries;
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
    public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWitAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;
        public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetLast3BlogsWitAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetLast3BlogsWithAuthors();
            return values.Select(x => new GetLast3BlogsWitAuthorsQueryResult
            {
                AuthorID = x.AuthorID,
                BlogID = x.BlogID,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                AuthorName = x.Author.Name
            }).ToList();
        }
    }
}
