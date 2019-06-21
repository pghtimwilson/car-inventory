using System.Collections.Generic;
using car_inventory_backend.Data;

namespace car_inventory_backend.Data
{
    public interface IFeatureRepository {
        IList<Feature> List {get;}
    }

    public class FeatureRepository : IFeatureRepository {
        public IList<Feature> List {
            get {
                var features = new List<Feature>();
                return features;
            }
        }
    }
}