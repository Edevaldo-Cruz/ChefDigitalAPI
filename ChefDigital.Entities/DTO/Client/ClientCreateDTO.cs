using ChefDigital.Entities.Entities;
using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChefDigital.Entities.DTO.Client
{
    public class ClientCreateDTO
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }


        public Entities.Client ToClient()
        {
            Entities.Client clientNew = new Entities.Client()
            {
                FirstName = FirstName,
                Surname = Surname,
                Telephone = Telephone,
                Email = Email,
                Active = true,
            };
            return clientNew;
        }

        public Entities.Address ToAddress()
        {
            Entities.Address address = new Entities.Address()
            {
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
