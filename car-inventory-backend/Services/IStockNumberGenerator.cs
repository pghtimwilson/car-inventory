using System;
using System.Linq;

namespace car_inventory_backend.Services
{
    public interface IStockNumberGenerator {
        string GenerateStockNumber();
    }

    public class StockNumberGenerator : IStockNumberGenerator {
        public string GenerateStockNumber(){
            return Guid.NewGuid().ToString("n").Substring(0, 8);
        }
    }
}