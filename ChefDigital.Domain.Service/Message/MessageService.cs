using ChefDigital.Domain.Interfaces.Message;
using ChefDigital.Entities.DTO;
using System.Net;
using System.Net.Mail;

namespace ChefDigital.Domain.Service.Message
{
    public class MessageService : IMessageService
    {
        private string email = "email";
        private string password = "email";

        public void SendMessage(OrderCreateDTO order)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(email, password),
                    EnableSsl = true,
                };
                
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(email),
                    Subject = "Atualização do Status do Seu Pedido",
                    Body = "Corpo do E-mail",
                };

                mail.To.Add(order.Email);

                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar o e-mail: {ex.Message}");
            }
        }
    }
}
