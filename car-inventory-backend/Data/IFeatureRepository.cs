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

                features.Add(new Feature
                {
                    Type = FeatureType.Doors,
                    Description = "2-door",
                    RetailPrice = 0
                });

                features.Add(new Feature
                {
                    Type = FeatureType.Doors,
                    Description = "4-door",
                    RetailPrice = 2500
                });

                features.Add(new Feature
                {
                    Type = FeatureType.Fuel,
                    Description = "Gas",
                    RetailPrice = 0
                });

                features.Add(new Feature
                {
                    Type = FeatureType.Fuel,
                    Description = "Hybrid",
                    RetailPrice = 10000
                });

                features.Add(new Feature
                {
                    Type = FeatureType.Fuel,
                    Description = "Electric",
                    RetailPrice = 15000
                });

                features.Add(new Feature
                {
                    Type = FeatureType.Transmission,
                    Description = "Automatic",
                    RetailPrice = 1000
                });

                features.Add(new Feature
                {
                    Type = FeatureType.Transmission,
                    Description = "Manual",
                    RetailPrice = 0
                });

                features.Add(new Feature
                {
                    Type = FeatureType.Interior,
                    Description = "Cloth",
                    RetailPrice = 0
                });

                return features;
            }
        }
    }
}