using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Address;
using Moq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.InteropServices;
using Xunit;

namespace ChefDigital.Domain.Service.Test.Address
{
    public class AddressEditServiceTest
    {
        [Fact]
        [Trait("Description", "Teste unitário para garantir que o método EditAsync possa editar um endereço quando chamado.")]
        public async Task EditAsync_MustEditAddress_WhenCalled()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var client = new ChefDigital.Entities.Entities.Client { Id = Guid.NewGuid() };
            var address = new ChefDigital.Entities.Entities.Address
            {
                Id = id,
                ClientId = client.Id,
                Street = "Rua Teste",
                City = "Cidade Teste",
                Number = 123,
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678"
            };
            address.SetDataAlteracao(DateTime.Now);

            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(address);

            var clientRepositoryMock = new Mock<IClientRepository>();
            clientRepositoryMock.Setup(repo => repo
                .ExistsAsync(It.IsAny<Expression<Func<Entities.Entities.Client, bool>>>()))
                .ReturnsAsync(true);

            addressRepositoryMock.Setup(repo => repo
                .Edit(It.IsAny<Entities.Entities.Address>()))
                .ReturnsAsync(address);

            var addessEditService = new AddressEditService(addressRepositoryMock.Object, clientRepositoryMock.Object);

            //Act
            var result = await addessEditService.EditAsync(id, address);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ChangeDate);
            Assert.Equal(client.Id, result.ClientId);
            Assert.Equal(address.Street, result.Street);
            Assert.Equal(address.City, result.City);
            Assert.Equal(address.Number, result.Number);
            Assert.Equal(address.Neighborhood, result.Neighborhood);
            Assert.Equal(address.ZipCode, result.ZipCode);

        }

        [Fact]
        [Trait("Description", "Teste unitário para garantir que o método EditAsync deve notificar quando um endereço não é encontrado.")]
        public async Task EditAsync_MustTakeNotificationOfAddressNotFound()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var client = new Entities.Entities.Client { Id = Guid.NewGuid() };
            var address = new Entities.Entities.Address
            {
                Id = id,
                ClientId = client.Id,
                Street = "Rua Teste",
                City = "Cidade Teste",
                Number = 123,
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678"
            };
            address.SetDataAlteracao(DateTime.Now);

            var addressRepositoryMock = new Mock<IAddressRepository>();
           
            var clientRepositoryMock = new Mock<IClientRepository>();
            clientRepositoryMock.Setup(repo => repo
                .ExistsAsync(It.IsAny<Expression<Func<Entities.Entities.Client, bool>>>()))
                .ReturnsAsync(true);

            addressRepositoryMock.Setup(repo => repo
                .Edit(It.IsAny<Entities.Entities.Address>()))
                .ReturnsAsync(address);

            var addessEditService = new AddressEditService(addressRepositoryMock.Object, clientRepositoryMock.Object);

            //Act
            var result = addessEditService.EditAsync(id, address);

            //Assert
            Assert.NotNull(result.Result.Notitycoes);
            Assert.Contains("O endereço não foi encontrado.", result.Result.Notitycoes.Select(n => n.Message));
            Assert.Null(result.Result.Street);
            Assert.Null(result.Result.City);
            Assert.Equal(0, result.Result.Number);
            Assert.Null(result.Result.Neighborhood);
            Assert.Null(result.Result.ZipCode);
        }

        [Fact]
        [Trait("Description", "Teste unitário para garantir que o método EditAsync deve notificar quando um cliente não é encontrado.")]
        public async Task EditAsync_MustTakeNotificationOfClentNotFound()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var client = new Entities.Entities.Client { Id = Guid.NewGuid() };
            var address = new Entities.Entities.Address
            {
                Id = id,
                ClientId = client.Id,
                Street = "Rua Teste",
                City = "Cidade Teste",
                Number = 123,
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678"
            };
            address.SetDataAlteracao(DateTime.Now);

            var addressRepositoryMock = new Mock<IAddressRepository>();
            addressRepositoryMock.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(address);

            var clientRepositoryMock = new Mock<IClientRepository>();

            addressRepositoryMock.Setup(repo => repo
                .Edit(It.IsAny<Entities.Entities.Address>()))
                .ReturnsAsync(address);

            var addessEditService = new AddressEditService(addressRepositoryMock.Object, clientRepositoryMock.Object);

            //Act
            var result = addessEditService.EditAsync(id, address);

            //Assert
            Assert.NotNull(result.Result.Notitycoes);
            Assert.Contains("O cliente não foi encontrado.", result.Result.Notitycoes.Select(n => n.Message));
            Assert.Null(result.Result.Street);
            Assert.Null(result.Result.City);
            Assert.Equal(0, result.Result.Number);
            Assert.Null(result.Result.Neighborhood);
            Assert.Null(result.Result.ZipCode);
        }
    }
}

