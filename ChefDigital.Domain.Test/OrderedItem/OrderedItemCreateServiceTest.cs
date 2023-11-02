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
        [Trait("Description", "Verifica se o método CreateAsync retorna true quando chamado com todos os campos preenchidos")]
        public async Task CreateAsync_MustReturnIsSuccessTrue_WhenCalled()
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
            Assert.True(result.IsSuccess );
            Assert.Equal(result.OrderedItem.Id, orderedItem.Id);
            Assert.Equal(result.OrderedItem.Item, orderedItem.Item);
            Assert.Equal(result.OrderedItem.UnitValue, orderedItem.UnitValue);
            Assert.Equal(result.OrderedItem.ItemQuantity, orderedItem.ItemQuantity);
            Assert.Equal(result.OrderedItem.TotalItemValue,(orderedItem.UnitValue * orderedItem.ItemQuantity));
        }

        [Fact]
        [Trait("Description", "Verifica se o método CreateAsync retorna notificação quando OrderId não é informado.")]
        public async Task CreateAsync_MustReturnNotificationTheOrderIdFieldMustBeFilled_WhenCalled()
        {
            //Arrange
            var orderedItem = new Entities.Entities.OrderedItem
            {
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
            Assert.NotNull(result.OrderedItem);
            Assert.Equal( "O campo 'OrderId' deve ser preenchido.", result.OrderedItem.Notitycoes[0].Message);
            Assert.Null(result.OrderedItem.Item);
            Assert.Equal(0, result.OrderedItem.UnitValue);
            Assert.Equal(0, result.OrderedItem.ItemQuantity);
            Assert.Equal(0, result.OrderedItem.TotalItemValue);
        }

        [Fact]
        [Trait("Description", "Verifica se o método CreateAsync retorna notificação quando Item não é informado.")]
        public async Task CreateAsync_MustReturnNotificationTheItemFieldMustBeFilled_WhenCalled()
        {
            //Arrange
            var orderedItem = new Entities.Entities.OrderedItem
            {
                OrderId = Guid.NewGuid(),
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
            Assert.NotNull(result.OrderedItem);
            Assert.Equal("O campo 'Item' deve ser preenchido.", result.OrderedItem.Notitycoes[0].Message);
            Assert.Null(result.OrderedItem.Item);
            Assert.Equal(0, result.OrderedItem.UnitValue);
            Assert.Equal(0, result.OrderedItem.ItemQuantity);
            Assert.Equal(0, result.OrderedItem.TotalItemValue);
        }

        [Fact]
        [Trait("Description", "Verifica se o método CreateAsync retorna notificação quando UnitValue não é informado.")]
        public async Task CreateAsync_MustReturnNotificationTheUnitValueFieldMustBeFilled_WhenCalled()
        {
            //Arrange
            var orderedItem = new Entities.Entities.OrderedItem
            {
                OrderId = Guid.NewGuid(),
                Item = "Rice",
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
            Assert.NotNull(result.OrderedItem);
            Assert.Equal("O campo 'UnitValue' deve ser maior que zero.", result.OrderedItem.Notitycoes[0].Message);
            Assert.Null(result.OrderedItem.Item);
            Assert.Equal(0, result.OrderedItem.UnitValue);
            Assert.Equal(0, result.OrderedItem.ItemQuantity);
            Assert.Equal(0, result.OrderedItem.TotalItemValue);
        }

        [Fact]
        [Trait("Description", "Verifica se o método CreateAsync retorna notificação quando ItemQuantity não é informado.")]
        public async Task CreateAsync_MustReturnNotificationTheItemQuantityFieldMustBeFilled_WhenCalled()
        {
            //Arrange
            var orderedItem = new Entities.Entities.OrderedItem
            {
                OrderId = Guid.NewGuid(),
                Item = "Rice",
                UnitValue = 10
            };
            var orderedItemRepository = new Mock<IOrderedItemRepository>();
            orderedItemRepository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.OrderedItem>()))
                .ReturnsAsync(orderedItem);

            var orderedItemCreateService = new OrderedItemCreateService(orderedItemRepository.Object);

            //Act
            var result = await orderedItemCreateService.CreateAsync(orderedItem);

            //Assert
            Assert.NotNull(result.OrderedItem);
            Assert.Equal("O campo 'ItemQuantity' deve ser maior que zero.", result.OrderedItem.Notitycoes[0].Message);
            Assert.Null(result.OrderedItem.Item);
            Assert.Equal(0, result.OrderedItem.UnitValue);
            Assert.Equal(0, result.OrderedItem.ItemQuantity);
            Assert.Equal(0, result.OrderedItem.TotalItemValue);
        }
    }
}
