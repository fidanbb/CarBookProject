﻿using CarBookProject.Application.Interfaces.ReviewInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.ReviewRepositories
{
	public class ReviewRepository:IReviewRepository
	{
		private readonly CarBookContext _context;

		public ReviewRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<Review> GetReviewsByCarId(int carId)
		{
			var values = _context.Reviews.Where(x => x.CarID == carId).ToList();
			return values;
		}
	}
}
