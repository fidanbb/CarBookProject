using CarBookProject.Dtos.PricingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dtos.CarPricingDtos
{
    public class CreateCarPricingRangeDto
    {
        public List<PricingDetailDto> PricingDetails { get; set; }
        public int CarID { get; set; }
    
    }
}
