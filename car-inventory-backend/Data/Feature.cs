using System.Collections.Generic;

namespace car_inventory_backend.Data
{
    public class Feature
    {
        public Feature()
        {
            Options = new List<FeatureOption>();
        }

        public string Description { get; set; }

        public List<FeatureOption> Options { get; set; }
    }
}