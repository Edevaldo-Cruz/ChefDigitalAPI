using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Address;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Test.Address
{
    public class AddressListServiceTest
    {
        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método ListAsync retorna uma lista de endereços quando chamado.")]
        public async Task ListAsync_MustReturnAddressList_WhenCalled()
        {
            //Arrange
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(repo => repo
                .List())
                .ReturnsAsync(new List<Entities.Entities.Address>());

            var addressListService = new AddressListService(addressRepository.Object);

            //Act
            var reuslt = await addressListService.ListAsync();

            //Assert
            Assert.NotNull(reuslt);
            Assert.IsType<List<Entities.Entities.Address>>(reuslt);
        }
    }
}
