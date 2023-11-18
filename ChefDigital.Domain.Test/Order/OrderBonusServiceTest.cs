using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Order;
using Moq;

namespace ChefDigital.Domain.Service.Test.Order
{
    public class OrderBonusServiceTest
    {
        [Fact]
        [Trait("Description", "Teste unitario verifica se o desconto vai ser aplicado em 30% do valor informado.")]
        public async Task Bonus_MustApplyADiscountOnTopOfTheValue_WhenCalled()
        {
            //Arrange
            var orderRepository = new Mock<IOrderRepository>();
            Guid clientId = Guid.NewGuid();
            decimal value = 21;

            orderRepository.Setup(repo => repo
                .CheckClientOrders(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            var orderBonusService = new OrderBonusService(orderRepository.Object);

            //Act
            var result = await orderBonusService.Bonus(clientId, value);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result, value * 0.3m);
        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o desconto vai ser aplicado no valor maximo.")]
        public async Task Bonus_MustApplyMaximumDiscount_WhenCalled()
        {
            //Arrange
            var orderRepository = new Mock<IOrderRepository>();
            Guid clientId = Guid.NewGuid();
            decimal value = 250;

            orderRepository.Setup(repo => repo
                .CheckClientOrders(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            var orderBonusService = new OrderBonusService(orderRepository.Object);

            //Act
            var result = await orderBonusService.Bonus(clientId, value);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result,45);
        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o desconto não vai ser aplicado, por causa do valor minimo.")]
        public async Task Bonus_DiscountShouldNotBeApplied_WhenCalled()
        {
            //Arrange
            var orderRepository = new Mock<IOrderRepository>();
            Guid clientId = Guid.NewGuid();
            decimal value = 19.99m;

            orderRepository.Setup(repo => repo
                .CheckClientOrders(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            var orderBonusService = new OrderBonusService(orderRepository.Object);

            //Act
            var result = await orderBonusService.Bonus(clientId, value);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result, 0);
        }

        [Fact]
        [Trait("Description", "Teste unitario verifica se o desconto não vai ser aplicado por motivo de não se enquadrar na regra imposta.")]
        public async Task Bonus_YouShouldNotApplyADiscountBecauseItDoesNotFitTheRule_WhenCalled()
        {
            //Arrange
            var orderRepository = new Mock<IOrderRepository>();
            Guid clientId = Guid.NewGuid();
            decimal value = 59.99m;

            orderRepository.Setup(repo => repo
                .CheckClientOrders(It.IsAny<Guid>()))
                .ReturnsAsync(false);

            var orderBonusService = new OrderBonusService(orderRepository.Object);

            //Act
            var result = await orderBonusService.Bonus(clientId, value);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result, 0);
        }
    }
}
