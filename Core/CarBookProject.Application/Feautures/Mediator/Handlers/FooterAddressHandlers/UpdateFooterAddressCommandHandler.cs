﻿using CarBookProject.Application.Feautures.Mediator.Commands.FooterAddressCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.FooterAddressID);
            values.Phone = request.Phone;
            values.Address = request.Address;
            values.Description = request.Description;
            values.Email = request.Email;
            await _repository.UpdateAsync(values);
        }
    }
}
