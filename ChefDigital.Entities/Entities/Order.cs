using ChefDigital.Entities.Entities.Generics;
using ChefDigital.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefDigital.Entities.Entities
{
    public class Order : EntityGeneric
    {
        public Order()
        {
            Status = OrderStatusEnum.Processing;
        }

        [Required]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        [Required]
        public List<OrderedItem> Items { get; set; }
        [Required]
        public decimal Subtotal { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal TotalOrderValue { get; private set; }

        [Required]
        public OrderStatusEnum Status { get; private set; }

        public void SetTotal(decimal subtotal, decimal discount)
        {
            TotalOrderValue = subtotal - discount;
        }

        public void SetStatus()
        {
            if (Status < OrderStatusEnum.Sent)
            {
                Status++;
            }
        }

        public void SetStatusCanceled()
        {
            Status = OrderStatusEnum.Canceled;
        }


    }
}
