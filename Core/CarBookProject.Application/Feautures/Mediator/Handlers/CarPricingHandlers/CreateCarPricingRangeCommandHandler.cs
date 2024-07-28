using CarBookProject.Application.Feautures.Mediator.Commands.CarPricingCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Handlers.CarPricingHandlers
{
    public class CreateCarPricingRangeCommandHandler : IRequestHandler<CreateCarPricingRangeCommand>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public CreateCarPricingRangeCommandHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task Handle(CreateCarPricingRangeCommand request, CancellationToken cancellationToken)
        {
            var carPricingEntities = request.CarPricingRanges.Select(dto => new CarPricing
            {
                CarID=dto.CarID,
                PricingID= dto.PricingID,
                Amount = dto.Amount
            }).ToList();

            await _carPricingRepository.AddRange(carPricingEntities);
        }

    }
}



