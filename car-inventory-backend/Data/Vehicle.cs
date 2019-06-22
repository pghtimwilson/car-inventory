namespace car_inventory_backend.Data
{
    public class Vehicle
    {
        public Vehicle()
        {

        }

        public Vehicle(Make make, string model)
        {
            Make = make;
            Model = model;
        }

        public Make Make { get; set; }

        public string Model { get; set; }

        public string Year { get; set; }

        public VehicleType VehicleType { get; set; }

        public double RetailPrice { get; set; }
    }
}