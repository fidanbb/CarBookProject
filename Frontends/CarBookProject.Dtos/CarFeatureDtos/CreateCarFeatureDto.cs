using CarBookProject.Dtos.FeatureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dtos.CarFeatureDtos
{
    public class CreateCarFeatureDto
    {
        public List<ResultFeatureWithStatusDto> Features { get; set; }
        public int CarID { get; set; }
        
    }
}
