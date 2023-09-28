using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        //[Required(ErrorMessage = "OrderId é obrigatório")]
        public Guid OrderId { get; set; }

        //[ForeignKey("OrderId")]
        public Order Order { get; set; }

        //[Required(ErrorMessage = "Item é obrigatório")]
        [MaxLength(100, ErrorMessage = "Item deve ter no máximo 100 caracteres")]
        public string Item { get; set; }

        //[Required(ErrorMessage = "UnitValue é obrigatório")]
        public decimal UnitValue { get; set; }

        //[Required(ErrorMessage = "ItemQuantity é obrigatório")]
        public int ItemQuantity { get; set; }

        //[Required(ErrorMessage = "TotalItemValue é obrigatório")]
        public decimal TotalItemValue => UnitValue * ItemQuantity;
    }
}
