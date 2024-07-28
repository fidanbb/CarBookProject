using CarBookProject.Application.Dtos;
using CarBookProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Commands.CarPricingCommands
{
    public class CreateCarPricingRangeCommand:IRequest
    {
        public List<CreateCarPricingDto> CarPricingRanges { get; set; }

        public CreateCarPricingRangeCommand(List<CreateCarPricingDto> carPricingRanges)
        {
            CarPricingRanges = carPricingRanges;
        }
    }
}
