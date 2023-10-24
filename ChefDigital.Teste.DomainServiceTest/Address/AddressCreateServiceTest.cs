using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Address;
using Moq;
using Xunit;

namespace ChefDigital.Teste.DomainServiceTest.Address
{
    public class AddressCreateServiceTest
    {
        private readonly Mock<IAddressRepository> _addressRepositoryMock;
        private readonly AddressCreateService _addressCreateService;

        public AddressCreateServiceTest()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _addressCreateService = new AddressCreateService(_addressRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnNewAddress_WhenCalled()
        {
            // Arrange
            var clientId = Guid.NewGuid();
            var newClient = new ChefDigital.Entities.Entities.Address
            {
                Street = "Rua Teste",
                City = "Cidade Teste",
                Number = 123,
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678"
            };

            _addressRepositoryMock.Setup(repo => repo.Add(It.IsAny<ChefDigital.Entities.Entities.Address>()))
                          .Returns(Task.FromResult(newClient));
            // Act
            var result = await _addressCreateService.CreateAsync(clientId, newClient);

            // Assert
            Assert.NotNull(result);

            _addressRepositoryMock.Verify(repo => repo.Add(It.IsAny<ChefDigital.Entities.Entities.Address>()), Times.Once);
        }
    }
}
