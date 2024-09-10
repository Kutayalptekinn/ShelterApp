using Microsoft.AspNetCore.Mvc;
using ShelterApp.Business.Services.MailService;
using ShelterApp.Entities.Entities.Form;

namespace ShelterApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        public MailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        [HttpPost("Send")]
        public void SendEmail(Form form)
        {
            _emailSender.SendEmail("kutayalptekin3@gmail.com", form);
        }
    }
}
