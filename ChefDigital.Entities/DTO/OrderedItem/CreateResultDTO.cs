using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Entities.DTO.OrderedItem
{
    public class CreateResultDTO
    {
        public bool IsSuccess { get; set; }
        public Entities.OrderedItem OrderedItem { get; set; }
    }
}
