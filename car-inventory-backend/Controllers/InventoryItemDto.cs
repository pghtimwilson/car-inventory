namespace car_inventory_backend.Data
{
    public class InventoryItemDto {
        public string Id { get; set; }

        public string Make {get;set;}

        public string Model {get;set;}

        public string Year {get;set;}

        public string VehicleType {get;set;}

        public string Features {get;set;}

        public double CalculatedSalesPrice {get;set;}

        public double Markup {get;set;}

        public double RetailPrice {get;set;}
    }
}