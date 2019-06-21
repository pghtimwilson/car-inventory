using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace car_inventory_backend.Data
{

    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IVehicleRepository VehicleRepository;

        public InventoryController(IVehicleRepository vehicleRepository)
        {
            VehicleRepository = vehicleRepository;
        }

        // GET api/inventory
        [HttpGet]
        public IActionResult Get()
        {
            var vehicles = VehicleRepository.List;
            return Ok(JsonConvert.SerializeObject(vehicles));
        }

        //TODO - Add serverside validation on Post, business logic must be enforced server side as well.
    }
}