using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dtos.CarPricingDtos
{
    public class CreateCarPricingListDto
    {
        public List<CreateCarPricingDto> CarPricingRanges { get; set; }
    }
}
