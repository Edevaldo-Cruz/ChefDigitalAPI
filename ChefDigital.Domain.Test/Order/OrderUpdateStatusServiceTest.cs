using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Order;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Test.Order
{
    public class OrderUpdateStatusServiceTest
    {
        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai ser salvo com o proximo status.")]
        public async Task UpdateOrderStatusAsync_MustChangeStatus_WhenCalling()
        {
            //Arrange
            var orderRepository = new Mock<IOrderRepository>();
            Guid id = Guid.NewGuid();

            var order = new Entities.Entities.Order
            {
                Id = id,
                ClientId = Guid.NewGuid(),
                Items = new List<Entities.Entities.OrderedItem>()
                {
                    new Entities.Entities.OrderedItem()
                    {
                        OrderId = Guid.NewGuid(),
                        UnitValue = 10,
                        ItemQuantity = 2,
                    }
                },
                Discount = 2,
            };

            orderRepository.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(order);

            var orderUpdateStatusService = new OrderUpdateStatusService(orderRepository.Object);

            //Act
            var result = await orderUpdateStatusService.UpdateOrderStatusAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(Entities.Enums.OrderStatusEnum.InPreparation, result.Status);
        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai retorna a notificação 'Pedido não encontrado.'")]
        public async Task UpdateOrderStatusAsync_MustReturnRequestNotFound_WhenCalled()
        {
            //Arrange
            var orderRepository = new Mock<IOrderRepository>();
            Guid id = Guid.NewGuid();

            var order = new Entities.Entities.Order
            {
                Id = id,
                ClientId = Guid.NewGuid(),
                Items = new List<Entities.Entities.OrderedItem>()
                {
                    new Entities.Entities.OrderedItem()
                    {
                        OrderId = Guid.NewGuid(),
                        UnitValue = 10,
                        ItemQuantity = 2,
                    }
                },
                Discount = 2,
            };

            var orderUpdateStatusService = new OrderUpdateStatusService(orderRepository.Object);

            //Act
            var result = await orderUpdateStatusService.UpdateOrderStatusAsync(id);

            //Assert           
            Assert.NotNull(result);
            Assert.True(result.Notitycoes.Any(n => n.Message == "Pedido não encontrado."));
        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai retorna a notificação 'O pedido já se encontra cancelado.")]
        public async Task UpdateOrderStatusAsync_MustReturnOrderIsAlreadyCanceled_WhenCalled()
        {
            //Arrange
            var orderRepository = new Mock<IOrderRepository>();
            Guid id = Guid.NewGuid();

            var order = new Entities.Entities.Order
            {
                Id = id,
                ClientId = Guid.NewGuid(),
                Items = new List<Entities.Entities.OrderedItem>()
                {
                    new Entities.Entities.OrderedItem()
                    {
                        OrderId = Guid.NewGuid(),
                        UnitValue = 10,
                        ItemQuantity = 2,
                    }
                },
                Discount = 2,
            };
            order.SetStatusCanceled();

            orderRepository.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(order);

            var orderUpdateStatusService = new OrderUpdateStatusService(orderRepository.Object);

            //Act
            var result = await orderUpdateStatusService.UpdateOrderStatusAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Notitycoes.Any(n => n.Message == "O pedido está cancelado."));
        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai retorna a notificação 'O pedido já foi entregue.")]
        public async Task UpdateOrderStatusAsync_MustReturnOrderAlreadyDelivered_WhenCalled()
        {
            //Arrange
            int status = 5;
            var orderRepository = new Mock<IOrderRepository>();
            Guid id = Guid.NewGuid();

            var order = new Entities.Entities.Order
            {
                Id = id,
                ClientId = Guid.NewGuid(),
                Items = new List<Entities.Entities.OrderedItem>()
                {
                    new Entities.Entities.OrderedItem()
                    {
                        OrderId = Guid.NewGuid(),
                        UnitValue = 10,
                        ItemQuantity = 2,
                    }
                },
                Discount = 2,
            };
            for (int i = 0; i < status; i++)
            {
                order.SetStatus();
            }

            orderRepository.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(order);

            var orderUpdateStatusService = new OrderUpdateStatusService(orderRepository.Object);

            //Act
            var result = await orderUpdateStatusService.UpdateOrderStatusAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Notitycoes.Any(n => n.Message == "O pedido finalizado, pois já foi entregue."));
        }

    }
}
