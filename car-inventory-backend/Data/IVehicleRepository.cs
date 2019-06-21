using System.Collections.Generic;

namespace car_inventory_backend.Data
{
    public interface IVehicleRepository
    {
        IList<Vehicle> List { get; }
    }

    public class VehicleRepository : IVehicleRepository
    {
        public IList<Vehicle> List {
            get
            {
                //TODO - This should really be connecting to a datasource and returning the stored entities.
                //There are a ton of 'magic strings' here... with a datasource this would not be the case. 
                var vehicles = new List<Vehicle>();

                vehicles.Add(new Vehicle
                {
                    VehicleType = VehicleType.Car,
                    Make = Make.Ford,
                    Model = "Focus",
                    RetailPrice = 16500.00
                });

                vehicles.Add(new Vehicle
                {
                    VehicleType = VehicleType.Car,
                    Make = Make.Ford,
                    Model = "Fusion",
                    RetailPrice = 22000.00
                });

                vehicles.Add(new Vehicle
                {
                    VehicleType = VehicleType.Truck,
                    Make = Make.Ford,
                    Model = "F-150",
                    RetailPrice = 24500.00
                });

                vehicles.Add(new Vehicle
                {
                    VehicleType = VehicleType.Car,
                    Make = Make.Lincoln,
                    Model = "MKZ",
                    RetailPrice = 34500.00
                });

                vehicles.Add(new Vehicle
                {
                    VehicleType = VehicleType.Car,
                    Make = Make.Lincoln,
                    Model = "Navigator",
                    RetailPrice = 56000.00
                });

                vehicles.Add(new Vehicle
                {
                    VehicleType = VehicleType.Car,
                    Make = Make.Dodge,
                    Model = "Avenger",
                    RetailPrice = 20500.00
                });

                vehicles.Add(new Vehicle
                {
                    VehicleType = VehicleType.Car,
                    Make = Make.Dodge,
                    Model = "Dart",
                    RetailPrice = 16000.00
                });

                vehicles.Add(new Vehicle
                {
                    VehicleType = VehicleType.Car,
                    Make = Make.Dodge,
                    Model = "Durango",
                    RetailPrice = 29500.00
                });

                return vehicles;
            } 
        }
    }
}
