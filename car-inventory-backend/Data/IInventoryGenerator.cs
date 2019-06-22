using System;
using System.Collections.Generic;

namespace car_inventory_backend.Data
{
    public interface IInventoryGenerator
    {
        List<InventoryItem> Generate(int seedCount = 10);
    }

    public class InventoryGenerator : IInventoryGenerator
    {
        private Random randomValue;

        private IVehicleRepository VehicleRepository;

        private IFeatureRepository FeatureRepository;

        public InventoryGenerator(IVehicleRepository vehicleRepository, IFeatureRepository featureRepository)
        {
            randomValue = new Random();
            VehicleRepository = vehicleRepository;
            FeatureRepository = featureRepository;
        }

        public List<InventoryItem> Generate(int seedCount = 10)
        {
            var inventory = new List<InventoryItem>();

            //Building sample inventory list.
            var x = seedCount;
            while (x > 0)
            {
                inventory.Add(RandomlyGenerate());
                x--;
            }

            return inventory;
        }

        private InventoryItem RandomlyGenerate()
        {
            var vehicleCount = VehicleRepository.List.Count;
            var randomIndex = this.randomValue.Next(0, vehicleCount - 1);

            var randomVehicle = VehicleRepository.List[randomIndex];
            var item = new InventoryItem();
            item.Vehicle = randomVehicle;

            var featureCount = FeatureRepository.List.Count;
            var featureRandomIndex = this.randomValue.Next(0, featureCount - 1);
            var randomFeature = FeatureRepository.List[featureCount];

            item.Features.Add(randomFeature);

            //Provide a random markup between 0 and 20 percent.
            item.Markup = this.randomValue.Next(0, 20);
            return item;
        }
    }

}