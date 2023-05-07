using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress("HotelierAdmin","mail");

            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxTo = new MailboxAddress("User",model.ReceiverMail);
            mimeMessage.To.Add(mailboxTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client= new SmtpClient();
            client.Connect("smtp.gmail.com", 587,false);
            client.Authenticate("egemenagustos351903@gmail.com", "ugvvefrwbuctzeau");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
