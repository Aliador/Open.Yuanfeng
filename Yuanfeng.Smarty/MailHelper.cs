using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Yuanfeng.Smarty
{
    public class MailHelper
    {
        public string Send(string host, int port, string user, string pwd, string display, string[] to, string[] cc, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(user, display, System.Text.Encoding.UTF8);

                foreach (var item in to)
                {
                    mail.To.Add(item);
                }

                foreach (var item in cc)
                {
                    mail.CC.Add(item);
                }

                mail.Subject = subject;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = body;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                SmtpClient client = new SmtpClient(host, port);
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Timeout = 10 * 1000;
                client.Credentials = new NetworkCredential(user, pwd);
                client.Send(mail);
            }
            catch (Exception exception)
            {
                return "Failed(" + exception.Message + ")";
            }
            return "Successed";
        }
    }
}
