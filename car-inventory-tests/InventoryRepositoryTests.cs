using car_inventory_backend.Data;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void ShouldSortInventoryByMake()
        {
            //Arrange
            var mockInventory = new List<InventoryItem>();
            mockInventory.Add(new InventoryItem()
            {
                Vehicle = new Vehicle(Make.Testla, "Titan")
            });

            mockInventory.Add(new InventoryItem()
            {
                Vehicle = new Vehicle(Make.Chevy, "Silverado")
            });

            var mockInventoryGenerator = new Mock<IInventoryGenerator>();
            mockInventoryGenerator.Setup(generator => generator.Generate(It.IsAny<int>())).Returns(mockInventory);

            var repository = new InventoryRepository(mockInventoryGenerator.Object);

            //Act
            var inventory = repository.List;

            //Assert
            Assert.AreEqual(inventory[0].Vehicle.Make, Make.Chevy);
            Assert.AreEqual(inventory[1].Vehicle.Make, Make.Testla);
        }

        [Test]
        public void ShouldSortInventoryModelsByNumericThenAlpha()
        {
            //Arrange
            var mockInventory = new List<InventoryItem>();
            mockInventory.Add(new InventoryItem()
            {
                Vehicle = new Vehicle(Make.Nissan, "Titan")
            });
            
            mockInventory.Add(new InventoryItem()
            {
                Vehicle = new Vehicle(Make.Nissan, "370z")
            });

            var mockInventoryGenerator = new Mock<IInventoryGenerator>();
            mockInventoryGenerator.Setup(generator => generator.Generate(It.IsAny<int>())).Returns(mockInventory);

            var repository = new InventoryRepository(mockInventoryGenerator.Object);

            //Act
            var inventory = repository.List;

            //Assert
            Assert.AreEqual(inventory[0].Vehicle.Model, "370z");
            Assert.AreEqual(inventory[1].Vehicle.Model, "Titan");
        }
    }
}