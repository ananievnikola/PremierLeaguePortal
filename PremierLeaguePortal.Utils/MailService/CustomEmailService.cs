using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeaguePortal.Utils.MailService
{
    public class CustomEmailService
    {
        public bool SendMail(EmailMessage mail)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("fplpbg@gmail.com"));  // replace with valid value 
            message.From = new MailAddress(mail.FromEmail);  // replace with valid value
            message.Subject = mail.Subject;
            message.Body = string.Format(body, mail.FromName, mail.FromEmail, mail.Message);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "fplpbg@gmail.com",  // replace with valid value
                    Password = "David7Beckham"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
            return true;
        }
    }
}
