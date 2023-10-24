using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Address;
using ChefDigital.Infra.Repository.Repositories;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ChefDigital.Teste.DomainServiceTest.Address
{
    public class AddressCreateServiceTest
    {
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

            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(repo => repo
                .Add(It.IsAny<ChefDigital.Entities.Entities.Address>()))
                .Returns<ChefDigital.Entities.Entities.Address>(Task.FromResult);

            var addressCreateService = new AddressCreateService(addressRepositoryMock.Object);

            // Act
            var result = await addressCreateService.CreateAsync(clientId, newClient);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clientId, result.ClientId);
            Assert.Equal(newClient.Street, result.Street);
            Assert.Equal(newClient.City, result.City);
            Assert.Equal(newClient.Number, result.Number);
            Assert.Equal(newClient.Neighborhood, result.Neighborhood);
            Assert.Equal(newClient.ZipCode, result.ZipCode);

            // Verifica se o método Add do repositório foi chamado com os parâmetros corretos
            addressRepositoryMock.Verify(repo => repo.Add(It.Is<ChefDigital.Entities.Entities.Address>(
                addr => addr.ClientId == clientId &&
                        addr.Street == newClient.Street &&
                        addr.City == newClient.City &&
                        addr.Number == newClient.Number &&
                        addr.Neighborhood == newClient.Neighborhood &&
                        addr.ZipCode == newClient.ZipCode)), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnIncompleteAddress_WhenFieldsAreMissing()
        {
            // Arrange
            var clientId = Guid.NewGuid();
            var newClient = new ChefDigital.Entities.Entities.Address
            {
                Street = "Rua Teste"
            };

            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(repo => repo
                .Add(It.IsAny<ChefDigital.Entities.Entities.Address>()))
                .Returns<ChefDigital.Entities.Entities.Address>(Task.FromResult);

            var addressCreateService = new AddressCreateService(addressRepositoryMock.Object);

            // Act
            var result = await addressCreateService.CreateAsync(clientId, newClient);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Notitycoes);
            Assert.Equal("Address", result.Notitycoes[0].PropertyName);
            Assert.Equal("Preenchas todos os campos", result.Notitycoes[0].Message);


        }
    }
}
