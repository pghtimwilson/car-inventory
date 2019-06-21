using System.Collections.Generic;
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
        private IVehicleRepository VehicleRepository;

        private IFeatureRepository FeatureRepository;

        public InventoryController(IInventoryRepository inventoryRepository, IVehicleRepository vehicleRepository, IFeatureRepository featureRepository)
        {
            InventoryRepository = inventoryRepository;
            VehicleRepository = vehicleRepository;
            FeatureRepository = featureRepository;
        }

        // GET api/inventory
        [HttpGet]
        public IActionResult Get()
        {
            var inventory = InventoryRepository.List;

            //TODO - This is messy with left-right mappings, replace with AutoMapper.
            var inventoryDtos = new List<InventoryItemDto>();
            foreach(var item in inventory){
                inventoryDtos.Add(new InventoryItemDto{
                    Make = item.Vehicle.Make.ToString("g"),
                    Model = item.Vehicle.Model,
                    Year = "2020",
                    VehicleType = item.Vehicle.VehicleType.ToString("g"),
                    Markup = item.Markup,
                    RetailPrice = item.Vehicle.RetailPrice,
                    
                    //TODO: This needs to take into account the Features retail price as well.
                    CalculatedSalesPrice = item.Vehicle.RetailPrice + (item.Vehicle.RetailPrice * (item.Markup/100))
                });
            }

            return Ok(JsonConvert.SerializeObject(inventoryDtos));
        }

        //TODO - Add Post, business logic must be enforced server side as well.
        //TODO - Add server side validation
    }
}