using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Order;
using Moq;

namespace ChefDigital.Domain.Service.Test.Order
{
    public class OrderCreateServiceTest
    {
        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai ser salvo corretamente quando informamos todos os campo obrigatorios.")]
        public async Task CreateAsync_MustSaveOrder_WhenCalled()
        {
            //Arrange
            var orderRepository = new Mock<IOrderRepository>();

            var order = new Entities.Entities.Order
            {
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
                Subtotal = 20,
                Discount = 2,
            };
            order.SetTotal(order.Subtotal, order.Discount);
            order.SetStatus();

            orderRepository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Order>()))
                .ReturnsAsync(order);

            var orderCreateService = new OrderCreateService(orderRepository.Object);

            //Act
            var result = await orderCreateService.CreateAsync(order);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.ClientId, order.ClientId);
            Assert.Equal(result.Items.Count, order.Items.Count);
            Assert.Equal(result.Subtotal, order.Subtotal);
            Assert.Equal(result.Discount, order.Discount);
            Assert.Equal(result.TotalOrderValue, order.TotalOrderValue);
            Assert.Equal(result.Status, order.Status);
        }

    }
}

