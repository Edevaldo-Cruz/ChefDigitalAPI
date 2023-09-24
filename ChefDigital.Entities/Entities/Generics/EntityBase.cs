using ChefDigital.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Entities.Entities.Generics
{
    public class EntityBase 
    {
        protected EntityBase() 
        {
            Id = Guid.NewGuid();
            DataInclusao = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
