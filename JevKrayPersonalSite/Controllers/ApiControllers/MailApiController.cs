using JevKrayPersonalSite.Services.MailSender;
using Microsoft.AspNetCore.Mvc;

namespace JevKrayPersonalSite.Controllers.ApiControllers
{
    public class MailApiController : Controller
    {
        [HttpPost]
        public IActionResult MailSender(string Username, string Email, string Title, string Message)
        {
            var mail = CodeMail.CreatieMail(Username, Email, Title, Message);
            CodeMail.SendMail(mail);
            return Ok("Mail Sent");
        }
    }
}
