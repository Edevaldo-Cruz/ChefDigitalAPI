﻿using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Address;
using Moq;

namespace ChefDigital.Domain.Service.Test.Address
{
    public class AddressDisableServiceTest
    {
        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método DisableAsync desabilita um endereço quando chamado.")]
        public async Task DisableAsync_MustDisableAddress_WhenCalled()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var address = new ChefDigital.Entities.Entities.Address
            {
                Id = id,
                ClientId = Guid.NewGuid(),
                Street = "Rua Teste",
                City = "Cidade Teste",
                Number = 123,
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678",
                Active = true,
            };
            address.SetDateChange(DateTime.Now);

            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(address);

            var addressService = new AddressDisableService(addressRepository.Object);

            //Act
            var result = addressService.DisableAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Result.Active, false);
        }

        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método DisableAsync retorna uma notificação quando o endereço não é encontrado.")]
        public async Task DisableAsync_MustReturnNotificationAddressNotFound()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var address = new ChefDigital.Entities.Entities.Address
            {
                Id = id,
                ClientId = Guid.NewGuid(),
                Street = "Rua Teste",
                City = "Cidade Teste",
                Number = 123,
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678",
                Active = true,
            };
            address.SetDateChange(DateTime.Now);

            var addressRepository = new Mock<IAddressRepository>();
            var addressService = new AddressDisableService(addressRepository.Object);

            //Act
            var result = addressService.DisableAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Result.Notitycoes.Any(n => n.Message == "Cliente e endereço não encontrado."));
            Assert.Equal(result.Result.Active, false);
        }


        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método DisableAsync retorna uma notificação quando o endereço não é encontrado.")]
        public async Task DisableAsync_MustReturnNotificationAddressNotFound_()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var address = new ChefDigital.Entities.Entities.Address
            {
                Id = id,
                ClientId = Guid.NewGuid(),
                Street = "Rua Teste",
                City = "Cidade Teste",
                Number = 123,
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678",
                Active = false,
            };
            address.SetDateChange(DateTime.Now);

            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(address);

            var addressService = new AddressDisableService(addressRepository.Object);

            //Act
            var result = addressService.DisableAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Result.Notitycoes.Any(n => n.Message == "O endereço já se encontra inativo."));
            Assert.Equal(result.Result.Active, false);
        }
    }
}
