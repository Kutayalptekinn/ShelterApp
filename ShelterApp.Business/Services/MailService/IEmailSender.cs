using ShelterApp.Entities.Entities.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Business.Services.MailService
{
    public interface IEmailSender
    {
        void SendEmail(string toEmail, Form subject);
    }
}
