using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RepositoryLayer
{
    public class EmailService
    {
        public static void SendEmail(string email, string link)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("arjundemo1997@gmail.com", "Arjun1997@");

                MailMessage msgObj = new MailMessage();
                msgObj.To.Add(email);
                msgObj.From = new MailAddress("arjundemo1997@gmail.com");
                msgObj.Subject = "Password Reset Link";
                msgObj.Body = $"www.fundooapp.com/reset-password/{link}";
                client.Send(msgObj);
            }
        }
    }
}
