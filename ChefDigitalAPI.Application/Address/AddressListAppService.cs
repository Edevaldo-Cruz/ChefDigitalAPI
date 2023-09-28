using ChefDigital.Domain.Interfaces.Address;
using ChefDigitalAPI.Application.Address.Interface;

namespace ChefDigitalAPI.Application.Address
{
    public class AddressListAppService : IAddressListAppService
    {
        private readonly IAddressListService _addressListService;

        public AddressListAppService(IAddressListService addressListService)
        {
            _addressListService = addressListService;
        }

        public async Task<List<ChefDigital.Entities.Entities.Address>> List()
        {
            var resultado = await _addressListService.List();

            return resultado;
        }
    }
}
