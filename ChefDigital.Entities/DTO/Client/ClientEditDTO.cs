using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Entities.DTO.Client
{
    public class ClientEditDTO
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public Entities.Client ToClient()
        {
            Entities.Client client = new()
            {
                FirstName = FirstName,
                Surname = Surname,
                Telephone = Telephone,
                Email = Email,
                Active = Active
            };
            return client;
        }
    }
}
