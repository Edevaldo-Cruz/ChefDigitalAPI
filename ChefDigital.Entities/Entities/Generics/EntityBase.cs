using ChefDigital.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Entities.Entities.Generics
{
    public abstract class EntityBase : EntityGeneric
    {
        public bool Active { get; set; }
    }
}
