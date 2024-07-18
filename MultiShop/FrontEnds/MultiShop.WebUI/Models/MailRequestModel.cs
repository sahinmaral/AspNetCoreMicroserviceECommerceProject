namespace MultiShop.WebUI.Models
{
    public class MailRequestModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public SmtpClientSettings SmtpClientSettings { get; set; }
        public SenderMailInformations Sender { get; set; }
    }

    public class SmtpClientSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }

    public class SenderMailInformations
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
