using MimeKit;
using MailKit.Net.Smtp;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.MailService
{
    public class MailService : IMailService
    {
        public void SendEmail(MailRequestModel model)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("MultiShop", model.From));
            message.To.Add(new MailboxAddress("User", model.To));
            message.Subject = model.Subject;

            message.Body = new TextPart("plain")
            {
                Text = model.Body
            };

            using (var client = new SmtpClient())
            {
                client.Connect(model.SmtpClientSettings.Host, model.SmtpClientSettings.Port, false);
                client.Authenticate(model.Sender.Email, model.Sender.Password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
