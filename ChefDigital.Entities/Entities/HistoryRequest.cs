using ChefDigital.Entities.Entities.Generics;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefDigital.Entities.Entities
{
    public class HistoryRequest : EntityBase
    {
        public HistoryRequest(Guid idClient, string address, Guid idOrder)
        {
            ClientId = idClient;
            Address = address;
            OrderId = idOrder;
        }

        public HistoryRequest()
        {

        }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public string Address { get; set; }        
        public Guid OrderId { get; set; }
        public decimal ValueTotal { get; set; }

    }
}
