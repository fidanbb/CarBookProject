﻿using CarBookProject.Application.Feautures.Mediator.Queries.AppUserQueries;
using CarBookProject.Application.Feautures.Mediator.Results.AppUserResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Handlers.AppUserHandlers
{
	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		private readonly IRepository<AppUser> _appUserRepository;
		private readonly IRepository<AppRole> _appRoleRepository;

		public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
		{
			_appUserRepository = appUserRepository;
			_appRoleRepository = appRoleRepository;
		}

		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = new GetCheckAppUserQueryResult();

			var user = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);

			if(user == null)
			{
				values.IsExist = false;
			}
			else
			{
				values.IsExist = true;
				values.Username = request.Username;
				values.Name = user.Name;
				values.Surname=user.Surname;
				values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleId == user.AppUserId)).AppRoleName;
				values.Id=user.AppUserId;
			}


			return values;
		}
	}
}
