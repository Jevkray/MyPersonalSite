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
            private static string[] ReadTxt()
            {
                string path = "prdata.txt";

                using (StreamReader reader = new StreamReader(path))
                {
                    string[] InfoData = new string[5];
                    for (int i = 0; i < 5; i++)
                    {
                        InfoData[i] = reader.ReadLine();
                    }
                    return InfoData;
                }
            }
            public static MailMessage CreatieMail(string Username, string Email, string Title, string Message)
            {
                string[] InfoData = ReadTxt();

                var from = new MailAddress(InfoData[0], Username);
                var to = new MailAddress(InfoData[1]);
                var mail = new MailMessage(from, to);
                mail.Subject = Title;
                mail.Body = Message + "\n\n" + "Contact Email: " + Email;
                mail.From = from;
                return mail;
            }
            public static void SendMail(MailMessage mail)
            {
                string[] InfoData = ReadTxt();
                SmtpClient smtp = new SmtpClient(InfoData[2], Convert.ToInt32(InfoData[3]));
                smtp.Credentials = new NetworkCredential(InfoData[0], InfoData[4]);
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
        }
    }
}
