using ChefDigital.Entities.Entities.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefDigital.Entities.Entities
{
    public class OrderedItem : EntityGeneric
    {
        public OrderedItem()
        {
        }

        [Required]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public string Item { get; set; }
        [Required]
        public decimal UnitValue { get; set; }
        [Required]
        public int ItemQuantity { get; set; }
        [Required]
        public decimal TotalItemValue => UnitValue * ItemQuantity;
    }
}
