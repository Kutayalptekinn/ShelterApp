using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ShelterApp.Entities.Entities.Form;

namespace ShelterApp.Business.Services.MailService
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string toEmail, Form subject)
        {
            // Set up SMTP client
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("cagatay.alptekin038@gmail.com", "opax nnwa lrgh gcmf");

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("cagatay.alptekin038@gmail.com");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject.AdSoyad;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();

            mailBody.AppendFormat("<h1>YENİ MESAJ</h1>");
            mailBody.AppendFormat("<p>Mesaj: " + subject.Mesaj + "</p>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Gönderici Mail :" + subject.Email + "</p>");
            mailBody.AppendFormat("<br />");

            mailBody.AppendFormat("<p> Gönderici Numara: " + subject.Numara + "</p>");
            mailMessage.Body = mailBody.ToString();

            // Send email
            client.Send(mailMessage);
        }
    }
}
