using System.Collections.Generic;
using System.Linq;

namespace car_inventory_backend.Data
{
    public interface IInventoryRepository{
        IList<InventoryItem> List {get;}

        void Delete(string Id);
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

        public void Delete(string Id)
        {
            var foundIndex = -1;
            for (var i = 0; i < this.InventoryItems.Count(); i++)
            {
                if (this.InventoryItems[i].Id.Equals(Id))
                {
                    foundIndex = i;
                    break;
                }
            }

            if (foundIndex >= 0)
            {
                this.InventoryItems.RemoveAt(foundIndex);
            }
        }
    }
}