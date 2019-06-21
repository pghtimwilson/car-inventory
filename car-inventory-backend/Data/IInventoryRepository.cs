
using System;
using System.Collections.Generic;
using car_inventory_backend.Data;

namespace car_inventory_backend.Data
{
    public interface IInventoryRepository{
        IList<InventoryItem> List {get;}
    }

    public class InventoryRepository : IInventoryRepository {

        private Random randomValue;
        
        private IVehicleRepository VehicleRepository;

        private IFeatureRepository FeatureRepository;

        private IList<InventoryItem> InventoryItems;

        public InventoryRepository(IVehicleRepository vehicleRepository, IFeatureRepository featureRepository) {
            randomValue = new Random();
            VehicleRepository = vehicleRepository;
            FeatureRepository = featureRepository;

            // This will generate a random inventory collection.
            RandomlyGenerateInventory();
        }
        
        public IList<InventoryItem> List {
            get {
                return InventoryItems;
            }
        }

        private void RandomlyGenerateInventory(int seedCount = 10){
            var inventory = new List<InventoryItem>();
                
            //Building sample inventory list.
            var x = seedCount;
            while(x > 0){
                inventory.Add(RandomlyGenerate());
                x--;
            }

            InventoryItems = inventory;
        }

        //TODO This should be refactored, breaks SRP
        private InventoryItem RandomlyGenerate(){
            var vehicleCount = VehicleRepository.List.Count;
            var randomIndex = this.randomValue.Next(0, vehicleCount - 1);

            var randomVehicle = VehicleRepository.List[randomIndex];
            var item = new InventoryItem();
            item.Vehicle = randomVehicle;

            //TODO this should be refactored, this is also wrong but a placeholder for now as we need random options as well.
            //var featureCount = FeatureRepository.List.Count;
            //var featureRandomIndex = this.randomValue.Next(0, featureCount - 1);
            //var randomFeature = FeatureRepository.List[featureCount];
            
            //item.Features.Add(randomFeature);

            //Provide a random markup between 0 and 20 percent.
            item.Markup = this.randomValue.Next(0, 20);
            return item;
        }
    }
}