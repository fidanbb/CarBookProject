using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dtos.CarFeatureDtos
{
    public class CreateCarFeatureDetailDto
    {
        public int FeatureID { get; set; }
        public int CarID { get; set; }
    }
}
