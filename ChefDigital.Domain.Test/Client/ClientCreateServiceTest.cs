using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Client;
using Moq;
using System.Linq.Expressions;

namespace ChefDigital.Domain.Test.Client
{
    public class ClientCreateServiceTest
    {
        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método CreateAsync salva e retorna um novo cliente quando chamado.")]
        public async Task CreateAsync_MustSaveAndReturnANewClient_WhenCalled()
        {
            //Arrange
            var client = new Entities.Entities.Client
            {
                FirstName = "Jhon",
                Surname = "Yong",
                Telephone = "3232-3232",
                Email = "jhon_yong@gmail.com",
            };

            var clientRpository = new Mock<IClientRepository>();
            clientRpository.Setup(repo => repo
                .ExistsAsync(It.IsAny<Expression<Func<Entities.Entities.Client, bool>>>()))
                .ReturnsAsync(false);

            clientRpository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Client>()))
                .ReturnsAsync(client);

            var clientCreateService = new ClientCreateService(clientRpository.Object);

            //Act
            var result = await clientCreateService.CreateAsync(client);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.FirstName, client.FirstName);
            Assert.Equal(result.Surname, client.Surname);
            Assert.Equal(result.Telephone, client.Telephone);
            Assert.Equal(result.Email, client.Email);
        }

        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método CreateAsync retorna uma notificação quando chamado com um cliente que já está cadastrado.")]
        public async Task CreateAsync_MustReturnNotificationCustomerAlreadyRegistered_WhenCalled()
        {
            //Arrange
            var client = new Entities.Entities.Client
            {
                FirstName = "Jhon",
                Surname = "Yong",
                Telephone = "3232-3232",
                Email = "jhon_yong@gmail.com",
            };

            var clientRpository = new Mock<IClientRepository>();
            clientRpository.Setup(repo => repo
                .ExistsAsync(It.IsAny<Expression<Func<Entities.Entities.Client, bool>>>()))
                .ReturnsAsync(true);

            clientRpository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Client>()))
                .ReturnsAsync(client);

            var clientCreateService = new ClientCreateService(clientRpository.Object);

            //Act
            var result = await clientCreateService.CreateAsync(client);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Notitycoes);
            Assert.Equal("O cliente já está cadastrado.", result.Notitycoes[0].Message);
        }

        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método CreateAsync retorna uma notificação quando chamado com um cliente que não preenche o campo 'FirstName'.")]
        public async Task CreateAsync_ShouldReturnNotificationFillFirstName_WhenCalled()
        {
            //Arrange
            var client = new Entities.Entities.Client
            {
                Surname = "Yong",
                Telephone = "3232-3232",
                Email = "jhon_yong@gmail.com",
            };

            var clientRpository = new Mock<IClientRepository>();
            clientRpository.Setup(repo => repo
                .ExistsAsync(It.IsAny<Expression<Func<Entities.Entities.Client, bool>>>()))
                .ReturnsAsync(true);

            clientRpository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Client>()))
                .ReturnsAsync(client);

            var clientCreateService = new ClientCreateService(clientRpository.Object);

            //Act
            var result = await clientCreateService.CreateAsync(client);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Notitycoes);
            Assert.Equal("O campo 'FirstName' deve ser preenchido", result.Notitycoes[0].Message);
        }

        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método CreateAsync retorna uma notificação quando chamado com um cliente que não preenche o campo 'Surname'.")]
        public async Task CreateAsync_ShouldReturnNotificationFillSurname_WhenCalled()
        {
            //Arrange
            var client = new Entities.Entities.Client
            {
                FirstName = "Jhon",
                Telephone = "3232-3232",
                Email = "jhon_yong@gmail.com",
            };

            var clientRpository = new Mock<IClientRepository>();
            clientRpository.Setup(repo => repo
                .ExistsAsync(It.IsAny<Expression<Func<Entities.Entities.Client, bool>>>()))
                .ReturnsAsync(true);

            clientRpository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Client>()))
                .ReturnsAsync(client);

            var clientCreateService = new ClientCreateService(clientRpository.Object);

            //Act
            var result = await clientCreateService.CreateAsync(client);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Notitycoes);
            Assert.Equal("O campo 'Surname' deve ser preenchido", result.Notitycoes[0].Message);
        }

        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método CreateAsync retorna uma notificação quando chamado com um cliente que não preenche o campo 'Telephone'.")]
        public async Task CreateAsync_ShouldReturnNotificationFillTelephone_WhenCalled()
        {
            //Arrange
            var client = new Entities.Entities.Client
            {
                FirstName = "Jhon",
                Surname = "Yong",
                Email = "jhon_yong@gmail.com",
            };

            var clientRpository = new Mock<IClientRepository>();
            clientRpository.Setup(repo => repo
                .ExistsAsync(It.IsAny<Expression<Func<Entities.Entities.Client, bool>>>()))
                .ReturnsAsync(true);

            clientRpository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Client>()))
                .ReturnsAsync(client);

            var clientCreateService = new ClientCreateService(clientRpository.Object);

            //Act
            var result = await clientCreateService.CreateAsync(client);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Notitycoes);
            Assert.Equal("O campo 'Telephone' deve ser preenchido", result.Notitycoes[0].Message);
        }

        [Fact]
        [Trait("Description", "Teste unitário para verificar se o método CreateAsync retorna uma notificação quando chamado com um cliente que não preenche o campo 'Email'.")]
        public async Task CreateAsync_ShouldReturnNotificationFillEmail_WhenCalled()
        {
            //Arrange
            var client = new Entities.Entities.Client
            {
                FirstName = "Jhon",
                Surname = "Yong",
                Telephone = "3232-3232",
            };

            var clientRpository = new Mock<IClientRepository>();
            clientRpository.Setup(repo => repo
                .ExistsAsync(It.IsAny<Expression<Func<Entities.Entities.Client, bool>>>()))
                .ReturnsAsync(true);

            clientRpository.Setup(repo => repo
                .Add(It.IsAny<Entities.Entities.Client>()))
                .ReturnsAsync(client);

            var clientCreateService = new ClientCreateService(clientRpository.Object);

            //Act
            var result = await clientCreateService.CreateAsync(client);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Notitycoes);
            Assert.Equal("O campo 'Email' deve ser preenchido", result.Notitycoes[0].Message);
        }

    }
}
