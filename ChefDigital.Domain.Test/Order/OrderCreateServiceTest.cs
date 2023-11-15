using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Order;
using Moq;
using Xunit.Abstractions;

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
                Discount = 2,
            };
            order.SetSubtotal();
            order.SetTotal();
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

        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai retorna a notificação 'O campo 'ClientId' é obrigatório.'")]
        public async Task CreateAsync_MustReturnClientIdIsMandatory_WhenCalled()
        {
            //Arrange
            var orderRepository = new Mock<IOrderRepository>();

            var order = new Entities.Entities.Order
            {
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
            order.SetSubtotal();
            order.SetTotal();
            order.SetStatus();

            orderRepository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Order>()))
                .ReturnsAsync(order);

            var orderCreateService = new OrderCreateService(orderRepository.Object);

            //Act
            var result = await orderCreateService.CreateAsync(order);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Notitycoes.Any(n => n.Message == "O campo 'ClientId' é obrigatório"));

        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai retorna a notificação 'O campo 'Items' é obrigatório.'")]
        public async Task CreateAsync_MustReturnItemIsMandatory_WhenCalled()
        {
            //Arrange
            var orderRepository = new Mock<IOrderRepository>();

            var order = new Entities.Entities.Order
            {
                ClientId = Guid.NewGuid(),
                Discount = 2,
            };
            order.SetSubtotal();
            order.SetTotal();
            order.SetStatus();

            orderRepository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Order>()))
                .ReturnsAsync(order);

            var orderCreateService = new OrderCreateService(orderRepository.Object);

            //Act
            var result = await orderCreateService.CreateAsync(order);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Notitycoes.Any(n => n.Message == "O campo 'Items' é obrigatório"));

        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai retorna a soma correta no subtotal.'")]
        public async Task CreateAsync_MustReturnTheCorrectSumOfTheSubtotal_WhenCalled()
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
                    },
                     new Entities.Entities.OrderedItem()
                     {
                        OrderId = Guid.NewGuid(),
                        UnitValue = 5,
                        ItemQuantity = 3,
                     }
                }
            };
            order.SetSubtotal();
            order.SetTotal();
            order.SetStatus();


            orderRepository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Order>()))
                .ReturnsAsync(order);

            var orderCreateService = new OrderCreateService(orderRepository.Object);

            //Act
            var result = await orderCreateService.CreateAsync(order);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Subtotal, (order.Items[0].UnitValue * order.Items[0].ItemQuantity) + (order.Items[1].UnitValue * order.Items[1].ItemQuantity));

        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai retorna a soma correta no subtotal.'")]
        public async Task CreateAsync_MustReturnTheCorrectSumOfTheTotal_WhenCalled()
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
                    },
                     new Entities.Entities.OrderedItem()
                     {
                        OrderId = Guid.NewGuid(),
                        UnitValue = 5,
                        ItemQuantity = 3,
                     }
                }
            };
            order.Discount = 10;
            order.SetSubtotal();
            order.SetTotal();
            order.SetStatus();


            orderRepository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Order>()))
                .ReturnsAsync(order);

            var orderCreateService = new OrderCreateService(orderRepository.Object);

            //Act
            var result = await orderCreateService.CreateAsync(order);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.TotalOrderValue, (order.Subtotal - order.Discount));

        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o pedido vai retorna a notificação 'O campo 'Discount' não pode ser negativo'.")]
        public async Task CreateAsync_MustReturnDiscountCannotBeNegative_WhenCalled_()
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
                    },
                     new Entities.Entities.OrderedItem()
                     {
                        OrderId = Guid.NewGuid(),
                        UnitValue = 5,
                        ItemQuantity = 3,
                     }
                }
            };
            order.Discount = -10;
            order.SetSubtotal();
            order.SetTotal();
            order.SetStatus();

            orderRepository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Order>()))
                .ReturnsAsync(order);

            var orderCreateService = new OrderCreateService(orderRepository.Object);

            //Act
            var result = await orderCreateService.CreateAsync(order);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Notitycoes.Any(n => n.Message == "O campo 'Discount' não pode ser negativo"));

        }
    }
}

