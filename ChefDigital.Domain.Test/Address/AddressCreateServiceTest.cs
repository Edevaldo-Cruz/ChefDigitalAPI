using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Address;
using ChefDigital.Entities.Entities;
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
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var clientId = Guid.NewGuid();
            var newAddress = new ChefDigital.Entities.Entities.Address
            {
                Street = "Rua Teste",
                City = "Cidade Teste",
                Number = 123,
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678"
            };

            var client = new Entities.Entities.Client
            { 
                Id = clientId,
            };

            addressRepositoryMock.Setup(repo => repo
                .Add(It.IsAny<ChefDigital.Entities.Entities.Address>()))
                .Returns<ChefDigital.Entities.Entities.Address>(Task.FromResult);

            clientRepositoryMock.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(client);

            var addressCreateService = new AddressCreateService(addressRepositoryMock.Object, clientRepositoryMock.Object);

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
        }

        [Fact]
        [Trait("Description", "Verifica se o método CreateAsync retorna o campo 'Street' é obrigatório.")]
        public async Task CreateAsync_MustReturnStreetFieldIsRequiredWhenCalled()
        {
            // Arrange
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var clientId = Guid.NewGuid();
            var newClient = new ChefDigital.Entities.Entities.Address
            {
                City = "Cidade Teste",
                Number = 123,
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678"
            };

            var client = new Entities.Entities.Client
            {
                Id = clientId,
            };

            addressRepositoryMock.Setup(repo => repo
                .Add(It.IsAny<ChefDigital.Entities.Entities.Address>()))
                .Returns<ChefDigital.Entities.Entities.Address>(Task.FromResult);

            clientRepositoryMock.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(client);

            var addressCreateService = new AddressCreateService(addressRepositoryMock.Object, clientRepositoryMock.Object);

            // Act
            var result = await addressCreateService.CreateAsync(clientId, newClient);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Notitycoes);
            Assert.Equal("Address", result.Notitycoes[0].PropertyName);
            Assert.Equal("O campo 'Street' é obrigatório", result.Notitycoes[0].Message);
        }

        [Fact]
        [Trait("Description", "Verifica se o método CreateAsync retorna o campo 'City' é obrigatório.")]
        public async Task CreateAsync_MustReturnCityFieldIsRequiredWhenCalled()
        {
            // Arrange
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();

            var clientId = Guid.NewGuid();
            var newClient = new ChefDigital.Entities.Entities.Address
            {
                Street = "Rua Teste",
                Number = 123,
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678"
            };

            var client = new Entities.Entities.Client
            {
                Id = clientId,
            };

            addressRepositoryMock.Setup(repo => repo
                .Add(It.IsAny<ChefDigital.Entities.Entities.Address>()))
                .Returns<ChefDigital.Entities.Entities.Address>(Task.FromResult);

            clientRepositoryMock.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(client);

            var addressCreateService = new AddressCreateService(addressRepositoryMock.Object, clientRepositoryMock.Object);

            // Act
            var result = await addressCreateService.CreateAsync(clientId, newClient);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Notitycoes);
            Assert.Equal("Address", result.Notitycoes[0].PropertyName);
            Assert.Equal("O campo 'City' é obrigatório", result.Notitycoes[0].Message);
        }

        [Fact]
        [Trait("Description", "Verifica se o método CreateAsync retorna o campo 'Number' deve ser um número positivo.")]
        public async Task CreateAsync_MustReturnNumberFieldIsRequiredWhenCalled()
        {
            // Arrange
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var clientId = Guid.NewGuid();
            var newClient = new ChefDigital.Entities.Entities.Address
            {
                Street = "Rua Teste",
                City = "Cidade Teste",
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678"
            };

            var client = new Entities.Entities.Client
            {
                Id = clientId,
            };

            addressRepositoryMock.Setup(repo => repo
                .Add(It.IsAny<ChefDigital.Entities.Entities.Address>()))
                .Returns<ChefDigital.Entities.Entities.Address>(Task.FromResult);

            clientRepositoryMock.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(client);

            var addressCreateService = new AddressCreateService(addressRepositoryMock.Object, clientRepositoryMock.Object);

            // Act
            var result = await addressCreateService.CreateAsync(clientId, newClient);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Notitycoes);
            Assert.Equal("Address", result.Notitycoes[0].PropertyName);
            Assert.Equal("O campo 'Number' deve ser um número positivo", result.Notitycoes[0].Message);
        }

        [Fact]
        [Trait("Description", "Verifica se o método CreateAsync retorna o campo 'Neighborhood' é obrigatório.")]
        public async Task CreateAsync_MustReturnNeighborhoodFieldIsRequiredWhenCalled()
        {
            // Arrange
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var clientId = Guid.NewGuid();
            var newClient = new ChefDigital.Entities.Entities.Address
            {
                Street = "Rua Teste",
                City = "Cidade Teste",
                Number = 123,
                ZipCode = "12345-678"
            };

            var client = new Entities.Entities.Client
            {
                Id = clientId,
            };

            addressRepositoryMock.Setup(repo => repo
                .Add(It.IsAny<ChefDigital.Entities.Entities.Address>()))
                .Returns<ChefDigital.Entities.Entities.Address>(Task.FromResult);

            clientRepositoryMock.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(client);

            var addressCreateService = new AddressCreateService(addressRepositoryMock.Object, clientRepositoryMock.Object);

            // Act
            var result = await addressCreateService.CreateAsync(clientId, newClient);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Notitycoes);
            Assert.Equal("Address", result.Notitycoes[0].PropertyName);
            Assert.Equal("O campo 'Neighborhood' é obrigatório", result.Notitycoes[0].Message);
        }

        [Fact]
        [Trait("Description", "Verifica se o método CreateAsync retorna o campo 'ZipCode' é obrigatório.")]
        public async Task CreateAsync_MustReturnZipCodeFieldIsRequiredWhenCalled()
        {
            // Arrange
            var clientId = Guid.NewGuid();
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var newClient = new ChefDigital.Entities.Entities.Address
            {
                Street = "Rua Teste",
                City = "Cidade Teste",
                Number = 123,
                Neighborhood = "Bairro Teste"
            };

            var client = new Entities.Entities.Client
            {
                Id = clientId,
            };

            addressRepositoryMock.Setup(repo => repo
                .Add(It.IsAny<ChefDigital.Entities.Entities.Address>()))
                .Returns<ChefDigital.Entities.Entities.Address>(Task.FromResult);

            clientRepositoryMock.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(client);

            var addressCreateService = new AddressCreateService(addressRepositoryMock.Object, clientRepositoryMock.Object);

            // Act
            var result = await addressCreateService.CreateAsync(clientId, newClient);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Notitycoes);
            Assert.Equal("Address", result.Notitycoes[0].PropertyName);
            Assert.Equal("O campo 'ZipCode' é obrigatório", result.Notitycoes[0].Message);
        }
    }
}
