using ChefDigital.Entities.Entities.Generics;
using ChefDigital.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefDigital.Entities.Entities
{
    public class Order : EntityGeneric
    {
        private decimal _subtotal = 0;
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
        public decimal Subtotal
        {
            get { return _subtotal; }
            private set { _subtotal = value; }
        }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal TotalOrderValue { get; private set; }

        [Required]
        public OrderStatusEnum Status { get; private set; }

        public void SetSubtotal()
        {
            if (Items == null)
            {
                Subtotal = 0;
            }
            else
            {
                foreach (var item in Items)
                {
                    _subtotal += item.TotalItemValue;
                }
                Subtotal = _subtotal;
            }
        }

        public void SetTotal()
        {
            TotalOrderValue = Subtotal - Discount;
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
