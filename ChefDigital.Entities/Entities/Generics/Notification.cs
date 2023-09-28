using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChefDigital.Entities.Entities.Generics
{
    public class Notification
    {
        public Notification()
        {
            Notitycoes = new List<Notification>();
        }

        [NotMapped]
        public string PropertyName { get; set; }
        [NotMapped]
        public string Message { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Notification> Notitycoes { get; set; }
        [NotMapped]
        [JsonIgnore]
        public bool HasNotifications => Notitycoes.Count > 0;


    }
}
