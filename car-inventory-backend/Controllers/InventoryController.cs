using System;
using System.Collections.Generic;
using System.Linq;
using car_inventory_backend.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace car_inventory_backend.Data
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IInventoryRepository InventoryRepository;

        private IStockNumberGenerator StockNumberGenerator;

        private IFeatureRepository FeatureRepository;

        public InventoryController(IInventoryRepository inventoryRepository, IStockNumberGenerator stockNumberGenerator, IFeatureRepository featureRepository)
        {
            InventoryRepository = inventoryRepository;
            StockNumberGenerator = stockNumberGenerator;
            FeatureRepository = featureRepository;
        }

        // GET api/inventory
        [HttpGet]
        public IActionResult Get()
        {
            var inventory = InventoryRepository.List;

            var inventoryDtos = new List<InventoryItemDto>();
            foreach(var item in inventory){
                // This is fairly annoying (the left/right mapping) AutoMapper is great for things like this.
                // I like AutoMapper because it is configurable, testable and it helps clean up code substantially IMO.
                inventoryDtos.Add(new InventoryItemDto {
                    Id = item.Id,
                    Make = item.Vehicle.Make.ToString("g"),
                    Model = item.Vehicle.Model,
                    Year = "2020",
                    VehicleType = item.Vehicle.VehicleType.ToString("g"),
                    Markup = item.Markup,
                    RetailPrice = item.Vehicle.RetailPrice,
                    Features = String.Join(",", item.Features.Select(f => Enum.GetName(typeof(FeatureType), f.Type) + " " + f.Description).ToList()),
                    CalculatedSalesPrice = item.Vehicle.RetailPrice + (item.Vehicle.RetailPrice * (item.Markup/100)) + item.Features.Select(f => f.RetailPrice).Sum()
                });
            }

            return Ok(JsonConvert.SerializeObject(inventoryDtos));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            InventoryRepository.Delete(id);

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(InventoryItemRPC item){
            //Quantity in stock
            
            //It isn't enough to only do validation client side, for data integrity it must be done server side as well.
            //TODO - Add Post, business logic must be enforced server side as well.
            //TODO - Add server side validation
            var vehicle = new Vehicle {
                Make = (Make)Enum.Parse(typeof(Make), item.Make, true),
                Model = item.Model,
                Year = item.Year,
                VehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), item.Type, true),
                RetailPrice = item.RetailPrice,
            };

            //Parse Features
            var features = new List<Feature>();
            if (!string.IsNullOrEmpty(item.Fuel))
            {
                var fuel = FeatureRepository.List.FirstOrDefault(feature => feature.Type == FeatureType.Fuel && feature.Description.Equals(item.Fuel, StringComparison.InvariantCultureIgnoreCase));
                if(fuel != null)
                {
                    features.Add(fuel);
                }
            }

            if (!string.IsNullOrEmpty(item.Doors))
            {
                var doors = FeatureRepository.List.FirstOrDefault(feature => feature.Type == FeatureType.Doors && feature.Description.Equals(item.Doors, StringComparison.InvariantCultureIgnoreCase));
                if (doors != null)
                {
                    features.Add(doors);
                }
            }

            if (!string.IsNullOrEmpty(item.Interior))
            {
                var interior = FeatureRepository.List.FirstOrDefault(feature => feature.Type == FeatureType.Interior && feature.Description.Equals(item.Interior, StringComparison.InvariantCultureIgnoreCase));
                if (interior != null)
                {
                    features.Add(interior);
                }
            }

            if (!string.IsNullOrEmpty(item.Transmission))
            {
               var transmission = FeatureRepository.List.FirstOrDefault(feature => feature.Type == FeatureType.Transmission && feature.Description.Equals(item.Transmission, StringComparison.InvariantCultureIgnoreCase));
                if (transmission != null)
                {
                    features.Add(transmission);
                }
            }

            var newItem = new InventoryItem
            {
                Markup = item.Markup,
                Vehicle = vehicle,
                Features = features
            };

            //Assign unique stock number...
            newItem.StockNumber = StockNumberGenerator.GenerateStockNumber();
            
            InventoryRepository.AddItem(newItem);

            return Ok();
        }
    }
}