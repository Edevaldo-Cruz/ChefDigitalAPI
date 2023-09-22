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
        public string Name { get; set; }
        public string Telephone { get; set; }
        public bool Active { get; set; }
    }
}
