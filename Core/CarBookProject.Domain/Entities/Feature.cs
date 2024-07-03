using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Domain.Entities
{
    public class Feature
    {
        public int FeatureID { get; set; }
        private string Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
