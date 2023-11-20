using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Entities.DTO.Address;
using ChefDigitalAPI.Application.Address.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Address
{
    public class AddressAppService : IAddressAppService
    {
        private readonly IAddressDisableService _addressDisableService;
        private readonly IAddressEditService _addressEditService;
        private readonly IAddressListService _addressListService;
        private readonly IAddressListByIdClientService _addressListByIdClientService;
        private readonly IAddressCreateService _addressCreateService;

        public AddressAppService(IAddressDisableService addressDisableService,
                                    IAddressEditService addressEditService,
                                    IAddressListService addressListService,
                                    IAddressListByIdClientService addressListByIdClientService,
                                    IAddressCreateService addressCreateService)
        {
            _addressDisableService = addressDisableService;
            _addressEditService = addressEditService;
            _addressListService = addressListService;
            _addressListByIdClientService = addressListByIdClientService;
            _addressCreateService = addressCreateService;
        }

        public async Task<ChefDigital.Entities.Entities.Address> CreateAsync(Guid clientId, AddressCreateDTO address)
        {
            var result = await _addressCreateService.CreateAsync(clientId, address.ToAddress());

            return result;
        }

        public async Task<ChefDigital.Entities.Entities.Address> DisableAsync(Guid id)
        {
            return await _addressDisableService.DisableAsync(id);
        }

        public async Task<ChefDigital.Entities.Entities.Address> EditAsync(Guid id, AddressEditDTO address)
        {
            var resultado = await _addressEditService.EditAsync(id, address.ToAddress());
            return resultado;
        }

        public async Task<List<ChefDigital.Entities.Entities.Address>> ListAsync()
        {
            var resultado = await _addressListService.ListAsync();

            return resultado;
        }

        public async Task<List<ChefDigital.Entities.Entities.Address>> ListAsync(Guid id)
        {
            var result = await _addressListByIdClientService.ListAsync(id);
            return result;
        }
    }
}
