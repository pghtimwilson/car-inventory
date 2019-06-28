using System;
using System.Collections.Generic;
using car_inventory_backend.Services;

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

        private IStockNumberGenerator StockNumberGenerator;

        public InventoryGenerator(IVehicleRepository vehicleRepository, IFeatureRepository featureRepository, IStockNumberGenerator stockNumberGenerator)
        {
            randomValue = new Random();
            VehicleRepository = vehicleRepository;
            FeatureRepository = featureRepository;
            StockNumberGenerator = stockNumberGenerator;
        }

        public List<InventoryItem> Generate(int seedCount = 10)
        {
            var inventory = new List<InventoryItem>();

            //Building sample inventory list.
            var x = 1;
            while (x <= seedCount)
            {
                inventory.Add(RandomlyGenerate(x));
                x++;
            }

            return inventory;
        }

        private InventoryItem RandomlyGenerate(int x)
        {
            var vehicleCount = VehicleRepository.List.Count;
            var vehicleRandomIndex = this.randomValue.Next(0, vehicleCount - 1);

            var randomVehicle = VehicleRepository.List[vehicleRandomIndex];
            var item = new InventoryItem();
            item.StockNumber = StockNumberGenerator.GenerateStockNumber();
            item.Id = x.ToString(); 
            item.Vehicle = randomVehicle;

            var featureCount = FeatureRepository.List.Count;
            var featureRandomIndex = this.randomValue.Next(0, featureCount - 1);
            var randomFeature = FeatureRepository.List[featureRandomIndex];

            item.Features.Add(randomFeature);

            //Provide a random markup between 0 and 20 percent.
            item.Markup = this.randomValue.Next(0, 20);
            return item;
        }
    }

}