using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.OrderedItem;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Test.OrderedItem
{
    public class OrderedItemCreateServiceTest
    {
        [Fact]
        public async Task OrderedItem_MustReturnTrueWhenCalled()
        {
            //Arrange
            var orderedItem = new Entities.Entities.OrderedItem
            {
                OrderId = Guid.NewGuid(),
                Item = "Rice",
                UnitValue = 10,
                ItemQuantity = 2,
            };
            var orderedItemRepository = new Mock<IOrderedItemRepository>();

            orderedItemRepository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.OrderedItem>()))
                .ReturnsAsync(orderedItem);

            var orderedItemCreateService = new OrderedItemCreateService(orderedItemRepository.Object);

            //Act
            var result = await orderedItemCreateService.CreateAsync(orderedItem);

            //Assert
            Assert.True(result);
        }

       
    }
}
