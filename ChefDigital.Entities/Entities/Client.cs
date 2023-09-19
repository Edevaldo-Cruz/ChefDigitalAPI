using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Entities.Entities
{
    public class Client : EntityBase
    {
        public Client(string name, string telephone)
        {
            Name = name;
            Telephone = telephone;
        }

        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}
