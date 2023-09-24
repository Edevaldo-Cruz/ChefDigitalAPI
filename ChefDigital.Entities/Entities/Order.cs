using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ChefDigital.Entities.Entities
{
    public class Order : EntityBase
    {
        public Order(Guid clientId)
        {
            ClientId = clientId;
            Items = new List<OrderedItem>();
        }

        [Required(ErrorMessage = "ClientId é obrigatório")]
        public Guid ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        [Required(ErrorMessage = "Items é obrigatório")]
        public List<OrderedItem> Items { get; set; }

        [Required(ErrorMessage = "TotalOrderValue é obrigatório")]
        public decimal TotalOrderValue => CalculateTotalOrderValue();

        private decimal CalculateTotalOrderValue()
        {
            decimal total = 0;

            foreach (var item in Items)
            {
                total += item.TotalItemValue;
            }

            return total;
        }
    }
}
