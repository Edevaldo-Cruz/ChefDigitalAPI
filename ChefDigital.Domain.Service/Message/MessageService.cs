using ChefDigital.Domain.Interfaces.Message;
using ChefDigital.Entities.DTO;
using System.Net;
using System.Net.Mail;

namespace ChefDigital.Domain.Service.Message
{
    public class MessageService : IMessageService
    {
        private string email = "email";
        private string password = "password";

        public void SendMessage(OrderCreateNewClientDTO order, string textEmail)
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
                    Body = $@"Prezado Cliente,

                            Espero que esta mensagem o encontre bem.
                            {textEmail}
                            
                            Atenciosamente,

                            Edevaldo Cruz
                            Gerente Logistico
                            ChefDigital",
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
