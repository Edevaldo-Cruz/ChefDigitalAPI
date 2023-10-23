using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Entities.DTO
{
    public class OrderedItemDTO
    {        
        public string? Item { get; set; }
        public decimal UnitValue { get; set; }
        public int ItemQuantity { get; set; }

    }
}
