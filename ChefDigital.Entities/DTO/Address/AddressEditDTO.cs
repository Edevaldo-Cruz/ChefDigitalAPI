using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Entities.DTO.Address
{
    public class AddressEditDTO
    {
        public Guid ClientId { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public Entities.Address ToAddress()
        {
            Entities.Address address = new()
            {
                ClientId = ClientId,
                Street = Street,
                Number = Number,
                Neighborhood = Neighborhood,
                City = City,
                ZipCode = ZipCode
            };
            return address;
        }
    }
}
