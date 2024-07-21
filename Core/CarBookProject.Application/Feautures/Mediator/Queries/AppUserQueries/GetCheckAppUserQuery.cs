using CarBookProject.Application.Feautures.Mediator.Results.AppUserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Queries.AppUserQueries
{
	public class GetCheckAppUserQuery : IRequest<GetCheckAppUserQueryResult>
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
