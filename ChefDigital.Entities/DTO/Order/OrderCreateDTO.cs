using ChefDigital.Entities.Entities;
using System.Data;
using System.Text.RegularExpressions;

namespace ChefDigital.Entities.DTO
{
    public class OrderCreateDTO
    {
        public Guid ClientId { get; set; }
        public List<OrderedItemDTO>? OrderedItems { get; set; }

    }
}
