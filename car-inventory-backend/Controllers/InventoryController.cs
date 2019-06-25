using System;
using System.Collections.Generic;
using System.Linq;
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


        //TODO - Add Post, business logic must be enforced server side as well.
        //TODO - Add server side validation
    }
}