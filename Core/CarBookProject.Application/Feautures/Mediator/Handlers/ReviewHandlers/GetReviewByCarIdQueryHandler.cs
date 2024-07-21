﻿using CarBookProject.Application.Feautures.Mediator.Queries.ReviewQueries;
using CarBookProject.Application.Feautures.Mediator.Results.ReviewResults;
using CarBookProject.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _repository;
		public GetReviewByCarIdQueryHandler(IReviewRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetReviewsByCarId(request.Id);
			return values.Select(x => new GetReviewByCarIdQueryResult
			{
				CarID = x.CarID,
				Comment = x.Comment,
				CustomerImage = x.CustomerImage,
				CustomerName = x.CustomerName,
				RaytingValue = x.RaytingValue,
				ReviewDate = x.ReviewDate,
				ReviewID = x.ReviewID
			}).ToList();
		}
	}
}