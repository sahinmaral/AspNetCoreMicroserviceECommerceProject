using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.MailService
{
    public interface IMailService
    {
        void SendEmail(MailRequestModel model);
    }
}
