using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Client;
using Moq;
using System.Linq.Expressions;

namespace ChefDigital.Domain.Service.Test.Client
{
    public class ClientExistsServiceTest
    {
        [Fact]
        [Trait("Description", "Verifica se o método Exists retorna um cliente quando chamado")]
        public async Task Exists_MustReturnCustomer_WhenCalled()
        {
            //Arrange
            var clientRepository = new Mock<IClientRepository>();
            string firstname = "Jhon";
            string surname = "Yong";
            string Telephone = "3232-3232";

            clientRepository.Setup(repo => repo
                .ExistsEntityAsync(It.IsAny<Expression<Func<Entities.Entities.Client, bool>>>()))
                .ReturnsAsync(new Entities.Entities.Client());

            var clientExistsService = new ClientExistsService(clientRepository.Object);

            //Act
            var result = await clientExistsService.Exists(firstname, surname, Telephone);

            //Assert
            Assert.NotNull(result);
        }
    }
}
