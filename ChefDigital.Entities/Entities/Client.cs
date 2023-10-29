using ChefDigital.Entities.DTO.Client;
using ChefDigital.Entities.Entities.Generics;
using System.ComponentModel.DataAnnotations;

namespace ChefDigital.Entities.Entities
{
    public class Client : EntityBase
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string Email { get; set; }
        public List<Address> Addresses { get; set; }

        public Client()
        {
            SetDateChange(DateTime.MinValue);
            Active = true;
        }
        public void SetActiveFalse()
        {
            Active = false;
        }

        public ClientCreateDTO ToClientDTO()
        {
            ClientCreateDTO clientNew = new ClientCreateDTO()
            {
                //Id = this.Id,
                FirstName = this.FirstName,
                Surname = this.Surname,
                Telephone = this.Telephone,
                //Active = this.Active,
            };
            return clientNew;
        }

        public ClientListDTO ToClientListDTO()
        {
            ClientListDTO clientNew = new ClientListDTO()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                Surname = this.Surname,
                Telephone = this.Telephone,
                Active = this.Active,
                Addresses = this.Addresses
            };
            return clientNew;
        }

    }
}
