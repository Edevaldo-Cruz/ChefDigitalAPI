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
            InclusionDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime InclusionDate { get; private set; }
        public DateTime? ChangeDate { get; private set; }

        public void SetDataAlteracao (DateTime? dataAlteracao)
        {
            ChangeDate = dataAlteracao;
        }
    }
}
