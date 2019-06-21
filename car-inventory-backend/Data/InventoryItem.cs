
using System.Collections.Generic;
using car_inventory_backend.Data;

namespace car_inventory_backend.Data
{
    public class InventoryItem {

        public InventoryItem(){
            Features = new List<Feature>();
        }

        //Unique Assigned
        //Alpha Numeric Value
        public string StockNumber {get;set;}

        public Vehicle Vehicle {get;set;}

        public IList<Feature> Features {get;set;}

        public double Markup {get;set;}
    }
}