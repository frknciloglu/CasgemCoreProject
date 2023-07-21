using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Pizzapan.PresentationLayer.Models;
using MailKit.Net.Smtp;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class SendMailController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAdressFrom = new MailboxAddress("Admin", "clglufurkan@gmail.com");
            mimeMessage.From.Add(mailboxAdressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);


            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.MessageContent;
            mimeMessage.Body=bodyBuilder.ToMessageBody();
           
            mimeMessage.Subject = mailRequest.Subject;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("clglufurkan@gmail.com", "ktreiiblgocqeumu");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return View();
        }
    }
}
