using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Commands.FeatureCommands
{
    public class UpdateFeatureCommand:IRequest
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
    }
}
