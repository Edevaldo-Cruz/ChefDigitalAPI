namespace ChefDigitalAPI.Application.Client.Interface
{
    public interface IClientCreateAppService
    {
        Task<ChefDigital.Entities.Entities.Client> Create(ChefDigital.Entities.Entities.Client client);
    }
}
