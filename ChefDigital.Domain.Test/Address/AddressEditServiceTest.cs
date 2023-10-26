using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Address;
using Moq;
using System.Linq.Expressions;
using System.Net;
using Xunit;

namespace ChefDigital.Domain.Service.Test.Address
{
    public class AddressEditServiceTest
    {
        [Fact]
        public async Task EditAsync_MustEditAddress_WhenCalled()
        {
            //Arrange
            var client = new ChefDigital.Entities.Entities.Client{ Id = Guid.NewGuid() };
            var address = new ChefDigital.Entities.Entities.Address
            {
                Id = Guid.NewGuid(),
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
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(client);

            clientRepositoryMock.Setup(repo => repo
                .ExistsAsync(It.IsAny<Expression<Func<Entities.Entities.Client, bool>>>()))
                .ReturnsAsync(true);

            addressRepositoryMock.Setup(repo => repo
                .Edit(It.IsAny<Entities.Entities.Address>()))
                .ReturnsAsync(address);

            var addessEditService = new AddressEditService(addressRepositoryMock.Object, clientRepositoryMock.Object);

            //Act
            var result = await addessEditService.EditAsync(client.Id, address);

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

        //[Fact]
        //public async Task EditAsync_MustTakeNotificationOfAddressNotFound() 
        //{
        //    //Arrange
        //    var client = new Entities.Entities.Client { Id = Guid.NewGuid() };
        //    var address = new Entities.Entities.Address
        //    {
        //        Id = Guid.NewGuid(),
        //        ClientId = client.Id,
        //        Street = "Rua Teste",
        //        City = "Cidade Teste",
        //        Number = 123,
        //        Neighborhood = "Bairro Teste",
        //        ZipCode = "12345-678"
        //    };
        //    address.SetDataAlteracao(DateTime.Now);

        //    var addressRepositoryMock = new Mock<IAddressRepository>();
        //    addressRepositoryMock.Setup(repo => repo
        //    .GetEntityById())

        //    //Act

        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.Contains(reult.Notif..., "O endereço não foi encontrado.");
        //}
    }
}

