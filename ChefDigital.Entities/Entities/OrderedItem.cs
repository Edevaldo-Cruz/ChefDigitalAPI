using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Entities.Entities
{
    public class OrderedItem : EntityBase
    {
        public OrderedItem(Guid orderID, string item, decimal unitValue, int itemQuantity)
        {
            OrderId = orderID;
            Item = item;
            UnitValue = unitValue;
            ItemQuantity = itemQuantity;
        }

        public OrderedItem()
        {
            
        }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public string Item { get; set; }
        public decimal UnitValue { get; set; }
        public int ItemQuantity { get; set; }

        // Propriedade calculada para o valor total do item
        public decimal TotalItemValue => UnitValue * ItemQuantity;

    }
}
