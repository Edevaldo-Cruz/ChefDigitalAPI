using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Client;
using Moq;

namespace ChefDigital.Domain.Service.Test.Client
{
    public class ClientEditServiceTest
    {
        [Fact]
        [Trait("Description", "Teste unitário para garantir que o método EditAsync possa editar um cliente quando chamado.")]
        public async Task EditAsync_MustEditCustomer_WhenCalled()
        {
            //Arrange
            var clientRepository = new Mock<IClientRepository>();

            Guid id = Guid.NewGuid();
            var client = new Entities.Entities.Client
            {
                Id = Guid.NewGuid(),
                FirstName = "Jhon",
                Surname = "Yong",
                Telephone = "3232-3232",
                Email = "jhon_yong@gmail.com",
            };
            client.SetDateChange(DateTime.Now);

            clientRepository.Setup(repo => repo
                .GetEntityById(It.IsAny<Guid>()))
                .ReturnsAsync(new Entities.Entities.Client());

            clientRepository.Setup(repo => repo
                .Edit(It.IsAny<Entities.Entities.Client>()))
                .ReturnsAsync(client);

            var clientEditService = new ClientEditService(clientRepository.Object);

            //Act
            var result = await clientEditService.EditAsync(id, client);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ChangeDate);
            Assert.Equal(client.Id, result.Id);
            Assert.Equal(client.FirstName, result.FirstName);
            Assert.Equal(client.Surname, result.Surname);
            Assert.Equal(client.Telephone, result.Telephone);
            Assert.Equal(client.Email, result.Email);
        }

        [Fact]
        [Trait("Description", "Teste unitário para garantir que o método EditAsync deve notificar quando um cliente não é encontrado.")]
        public async Task EditAsync_MustReturnCustomerNotFound_WhenCalled()
        {
            //Arrange
            var clientRepository = new Mock<IClientRepository>();

            Guid id = Guid.NewGuid();
            var client = new Entities.Entities.Client
            {
                Id = Guid.NewGuid(),
                FirstName = "Jhon",
                Surname = "Yong",
                Telephone = "3232-3232",
                Email = "jhon_yong@gmail.com",
            };
            client.SetDateChange(DateTime.Now);

            clientRepository.Setup(repo => repo
                .Edit(It.IsAny<Entities.Entities.Client>()))
                .ReturnsAsync(client);

            var clientEditService = new ClientEditService(clientRepository.Object);

            //Act
            var result = await clientEditService.EditAsync(id, client);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"Cliente com o ID {id} não encontrado.", result.Notitycoes.Select(n => n.Message));
            Assert.NotNull(result.ChangeDate);
            Assert.Null(result.FirstName);
            Assert.Null(result.Surname);
            Assert.Null(result.Telephone);
            Assert.Null(result.Email);
        }
    }
}
