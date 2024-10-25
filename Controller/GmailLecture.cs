using MailKit.Net.Smtp;

namespace Controller
{
    public class GmailLecture
    {
        string email = "xalexox7@gmail.com";
        string password = "citiblac1"; 

        public GmailLecture()
        {
            
        }
        public void LeerCorreos()
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtpClient.Authenticate(email, password);
                // Send your message here
                smtpClient.Disconnect(true);
            }

        }
    }
}
