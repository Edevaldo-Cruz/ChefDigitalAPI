using ChefDigital.Entities.Entities.Generics;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefDigital.Entities.Entities
{
    public class Order : EntityBase
    {
        public Order(Guid clientId)
        {
            ClientId = clientId;
            Items = new List<OrderedItem>();           
        }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        [NotMapped]
        public List<OrderedItem> Items { get; set; }
        public decimal TotalOrderValue => CalculateTotalOrderValue();

        private decimal CalculateTotalOrderValue()
        {
            return Items.Where(item => item.OrderId == Id).Sum(item => item.TotalItemValue);
        }

        [ForeignKey("OrderId")]
        public Guid Id { get; set; } // Renomeie Id para OrderId

    }
}
