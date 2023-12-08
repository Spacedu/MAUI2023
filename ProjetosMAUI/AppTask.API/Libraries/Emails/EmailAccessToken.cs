using AppTask.Models;
using System.Net.Mail;

namespace AppTask.API.Libraries.Emails
{
    public class EmailAccessToken
    {
        private SmtpClient _smtp;

        public EmailAccessToken(SmtpClient smtp)
        {
            _smtp = smtp;
        }

        public void Send(UserModel userModel)
        {

        }
    }
}
