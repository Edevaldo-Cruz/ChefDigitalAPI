using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Entities.Entities
{
    public class Address : EntityBase
    {
        [Required]
        public Guid ClientId { get; set; }
        //[ForeignKey("ClientId")]
        //public Client Client { get; set; }

        [Required(ErrorMessage = "Street é obrigatório")]
        [MaxLength(100, ErrorMessage = "Street deve ter no máximo 100 caracteres")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Number é obrigatório")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Neighborhood é obrigatório")]
        [MaxLength(50, ErrorMessage = "Neighborhood deve ter no máximo 50 caracteres")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "City é obrigatório")]
        [MaxLength(50, ErrorMessage = "City deve ter no máximo 50 caracteres")]
        public string City { get; set; }

        [Required(ErrorMessage = "ZipCode é obrigatório")]
        [MaxLength(10, ErrorMessage = "ZipCode deve ter no máximo 10 caracteres")]
        public string ZipCode { get; set; }


        public Address(Guid clientId, string street, int number, string neighborhood, string city, string zipCode)
        {
            ClientId = clientId;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            ZipCode = zipCode;
        }

        public Address()
        {
            
        }
    }
}
