using ChefDigital.Entities.Entities;
using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Entities.DTO
{
    public class ClientDTO : EntityBase
    {
        public ClientDTO()
        {
            Addresses = new List<Address>();
        }

        public string FisrtName { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public List<Address> Addresses { get; set; }


        public Client ToClient()
        {
            Client clientNew = new Client()
            {
                FisrtName = this.FisrtName,
                Surname = this.Surname,
                Telephone = this.Telephone,
                Active = this.Active,
            };

            return clientNew;

        }

        
    }
}
