using System.Collections.Generic;
using System.Linq;

namespace car_inventory_backend.Data
{
    public interface IInventoryRepository{
        IList<InventoryItem> List {get;}
    }

    public class InventoryRepository : IInventoryRepository {

        private List<InventoryItem> InventoryItems;

        public InventoryRepository(IInventoryGenerator inventoryGenerator) {
            this.InventoryItems = inventoryGenerator.Generate();
        }
        
        public IList<InventoryItem> List {
            get {
                return InventoryItems.OrderBy(i => i.Vehicle.Make).OrderBy(i => i.Vehicle.Model).ToList();
            }
        }
    }
}