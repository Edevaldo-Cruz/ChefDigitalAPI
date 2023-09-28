using ChefDigital.Entities.DTO.Client;
using ChefDigital.Entities.Entities.Generics;
using System.ComponentModel.DataAnnotations;

namespace ChefDigital.Entities.Entities
{
    public class Client : EntityBase
    {
        public Client()
        {
            SetDataAlteracao(DateTime.MinValue);
            Active = true;
        }

        [Required(ErrorMessage = "FirstName é obrigatório")]
        [MaxLength(100, ErrorMessage = "FirstName deve ter no máximo 100 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname é obrigatório")]
        [MaxLength(100, ErrorMessage = "Surname deve ter no máximo 100 caracteres")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Telephone é obrigatório")]
        [MaxLength(20, ErrorMessage = "Telephone deve ter no máximo 20 caracteres")]
        public string Telephone { get; set; }

        public List<Address> Addresses { get; set; }

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
