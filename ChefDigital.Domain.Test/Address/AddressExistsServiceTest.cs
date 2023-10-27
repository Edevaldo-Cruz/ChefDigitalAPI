using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Address;
using Moq;
using System.Linq.Expressions;

namespace ChefDigital.Domain.Service.Test.Address
{
    
    public class AddressExistsServiceTest
    {
        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método IsAddressExists retorna 'true' quando chamado com um endereço existente.")]
        public async Task IsAddressExists_MustReturnTrue_WhenCalled()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            string street = "Av. Rio Branco";
            int number = 1500;

            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(repo => repo
                .ExistsAsync(It.IsAny<Expression<Func<Entities.Entities.Address, bool>>>()))
                .ReturnsAsync(true);

            var addressExistsService = new AddressExistsService(addressRepository.Object);

            //Act
            var result = addressExistsService.IsAddressExists(id, street, number);

            //Assert
            Assert.Equal(result.Result, true);

        }

        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método IsAddressExists retorna 'false' quando chamado com um endereço inexistente.")]
        public async Task IsAddressExists_MustReturnFalse_WhenCalled()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            string street = "Av. Rio Branco";
            int number = 1500;

            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(repo => repo
                .ExistsAsync(It.IsAny<Expression<Func<Entities.Entities.Address, bool>>>()))
                .ReturnsAsync(false);

            var addressExistsService = new AddressExistsService(addressRepository.Object);

            //Act
            var result = addressExistsService.IsAddressExists(id, street, number);

            //Assert
            Assert.Equal(result.Result, false);

        }
    }
}
