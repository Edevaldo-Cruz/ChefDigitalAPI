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
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "Street é obrigatório")]
        [MaxLength(100, ErrorMessage = "Street deve ter no máximo 100 caracteres")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Number é obrigatório")]
        [MaxLength(20, ErrorMessage = "Number deve ter no máximo 20 caracteres")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Neighborhood é obrigatório")]
        [MaxLength(50, ErrorMessage = "Neighborhood deve ter no máximo 50 caracteres")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "City é obrigatório")]
        [MaxLength(50, ErrorMessage = "City deve ter no máximo 50 caracteres")]
        public string City { get; set; }

        [Required(ErrorMessage = "State é obrigatório")]
        [MaxLength(50, ErrorMessage = "State deve ter no máximo 50 caracteres")]
        public string State { get; set; }

        [Required(ErrorMessage = "ZipCode é obrigatório")]
        [MaxLength(10, ErrorMessage = "ZipCode deve ter no máximo 10 caracteres")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Country é obrigatório")]
        [MaxLength(50, ErrorMessage = "Country deve ter no máximo 50 caracteres")]
        public string Country { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        protected Address()
        {

        }

        public Address(string street, string number, string neighborhood, string city, string state, string zipCode, string country)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }
    }
}
