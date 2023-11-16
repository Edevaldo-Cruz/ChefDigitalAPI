using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Order;
using ChefDigital.Entities.Entities;
using ChefDigital.Infra.Repository.Repositories;
using Moq;

namespace ChefDigital.Domain.Service.Test.Order
{
    public class OrderCancelServiceTest
    {
        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai ser salvo com o status cancelado.")]
        public async Task CancelOrderAsync_MustReturnOrderWithStatusCanceled_WhenCalled()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var orderRepository = new Mock<IOrderRepository>();
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

            var orderCancelService = new OrderCancelService(orderRepository.Object);

            //Act
            var result = await orderCancelService.CancelOrderAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Status, Entities.Enums.OrderStatusEnum.Canceled);

        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai retorna a notificação 'Pedido não encontrado.'")]
        public async Task CancelOrderAsync_MustReturnRequestNotFound_WhenCalled()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var orderRepository = new Mock<IOrderRepository>();
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

            var orderCancelService = new OrderCancelService(orderRepository.Object);

            //Act
            var result = await orderCancelService.CancelOrderAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Notitycoes.Any(n => n.Message == "Pedido não encontrado."));
        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai retorna a notificação 'O pedido já se encontra cancelado.")]
        public async Task CancelOrderAsync_MustReturnOrderIsAlreadyCanceled_WhenCalled()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var orderRepository = new Mock<IOrderRepository>();
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

            var orderCancelService = new OrderCancelService(orderRepository.Object);

            //Act
            var result = await orderCancelService.CancelOrderAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Notitycoes.Any(n => n.Message == "O pedido já se encontra cancelado."));
        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai retorna a notificação 'O pedido já se encontra cancelado.")]
        public async Task CancelOrderAsync_MustReturnOrderAlreadyDelivered_WhenCalled_()
        {
            //Arrange
            int status = 5;
            Guid id = Guid.NewGuid();
            var orderRepository = new Mock<IOrderRepository>();
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

            var orderCancelService = new OrderCancelService(orderRepository.Object);

            //Act
            var result = await orderCancelService.CancelOrderAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Notitycoes.Any(n => n.Message == "O pedido não pode ser cancelado pois já foi entregue."));
        }
    }
}
