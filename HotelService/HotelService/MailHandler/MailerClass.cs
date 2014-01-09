using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace HotelService.MailHandler
{
    public sealed class MailerClass
    {
        private static readonly MailerClass instance = new MailerClass();

        private MailerClass() { }

        public static MailerClass Instance
        {
            get
            {
                return instance;
            }
        }

        public void SendMail(string emailTo, string subject, string body)
        {
            string mailFromName = "Hotel de la DEF-TECH";
            string mailFromAddress = "hotelsysteem@def-tech.nl";

            MailMessage mail = new MailMessage(mailFromName + " " + mailFromAddress, emailTo, subject, body );

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.def-tech.nl";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("hotelsysteem@def-tech.nl", "S9nckOEI");

            smtp.Send(mail);
        }
    }
}