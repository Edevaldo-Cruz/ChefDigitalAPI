using Castle.Core.Resource;
using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Client;
using Moq;
using System.Linq.Expressions;

namespace ChefDigital.Domain.Service.Test.Client
{
    public class ClientListServiceTest
    {
        [Fact]
        [Trait("Description", "Verifica se o método ListAsync retorna uma lista de clientes")]
        public async Task ListAsync_MustReturnACustomerList_WhenCalled()
        {
            //Arrange
            var clientRepository = new Mock<IClientRepository>();

            clientRepository.Setup(repo => repo.ClientListFilter(It.IsAny<Expression<Func<Entities.Entities.Client, bool>>>()))
                .Returns(Task.FromResult(new List<Entities.DTO.Client.ClientListDTO>()));


            var clientListService = new ClientListService(clientRepository.Object);

            //Act
            var result = await clientListService.ListAsync();

            //Assert
            Assert.NotNull(result);
        }
    }
}
