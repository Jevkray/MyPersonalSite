using Docker.DotNet.Models;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection.PortableExecutable;

namespace JevKrayPersonalSite.Services
{
    namespace MailSender
    {
        internal class CodeMail
        {
            public static MailMessage CreatieMail(string Username, string Email, string Title, string Message)
            {
                var from = new MailAddress("eg.kray.work.stmp@gmail.com", Username);
                var to = new MailAddress("SemmiTwinsBoss@gmail.com");
                var mail = new MailMessage(from, to);
                mail.Subject = Title;
                mail.Body = Message + "\n\n" + "Contact Email: " + Email;
                mail.From = from;
                return mail;
            }
            public static void SendMail(MailMessage mail)
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("eg.kray.work.stmp@gmail.com", "cjzictfknfwjvmut");
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
        }
    }
}
