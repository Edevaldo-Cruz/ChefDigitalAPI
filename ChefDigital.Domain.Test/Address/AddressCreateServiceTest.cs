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
        [Trait("Description", "Verifica se o método CreateAsync retorna um endereço completo quando chamado com todos os campos preenchidos.")]
        public async Task CreateAsync_ShouldReturnNewAddress_WhenCalled()
        {
            // Arrange
            var clientId = Guid.NewGuid();
            var newAddress = new ChefDigital.Entities.Entities.Address
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
            var result = await addressCreateService.CreateAsync(clientId, newAddress);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clientId, result.ClientId);
            Assert.Equal(newAddress.Street, result.Street);
            Assert.Equal(newAddress.City, result.City);
            Assert.Equal(newAddress.Number, result.Number);
            Assert.Equal(newAddress.Neighborhood, result.Neighborhood);
            Assert.Equal(newAddress.ZipCode, result.ZipCode);

            // Verifica se o método Add do repositório foi chamado com os parâmetros corretos
            addressRepositoryMock.Verify(repo => repo.Add(It.Is<ChefDigital.Entities.Entities.Address>(
                addr => addr.ClientId == clientId &&
                        addr.Street == newAddress.Street &&
                        addr.City == newAddress.City &&
                        addr.Number == newAddress.Number &&
                        addr.Neighborhood == newAddress.Neighborhood &&
                        addr.ZipCode == newAddress.ZipCode)), Times.Once);
        }

        [Fact]
        [Trait("Description", "Verifica se o método CreateAsync retorna um endereço incompleto com notificação quando campos obrigatórios estão ausentes.")]
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
            Assert.Equal("Preencha todos os campos do endereço.", result.Notitycoes[0].Message);


        }
    }
}
