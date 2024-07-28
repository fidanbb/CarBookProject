using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dtos.CarPricingDtos
{
    public class PricingDetailDto
    {
        public int PricingID { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
