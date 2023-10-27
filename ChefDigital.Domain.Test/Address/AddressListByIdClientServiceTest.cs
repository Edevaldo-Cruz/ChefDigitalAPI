using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Address;
using ChefDigital.Infra.Repository.Repositories;
using Moq;

namespace ChefDigital.Domain.Service.Test.Address
{
    public class AddressListByIdClientServiceTest
    {
        [Fact]
        public async Task ListAsync_MustReturnAddressList_WhenCalled()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(repo => repo
                .ListByIdClient(It.IsAny<Guid>()))
                .ReturnsAsync(new List<Entities.Entities.Address>());

            var addressListByIdClientService = new AddressListByIdClientService(addressRepository.Object);

            //Act
            var result = await addressListByIdClientService.ListAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Entities.Entities.Address>>(result);

        }
    }
}
