using ChefDigital.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.Message
{
    public interface IMessageService
    {
        void SendMessage(Entities.DTO.OrderCreateDTO order, string text);
    }
}
