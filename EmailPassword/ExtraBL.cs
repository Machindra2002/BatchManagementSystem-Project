using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BatchManagementSystem.EmailPassword
{
    public class ExtraBL
    {
        public void SendMail(string email_address, string subject, string body)
        {
            var sender = new MailAddress("machindranikat@gmail.com","Mail from Machindra");
            var receiver = new MailAddress(email_address, email_address);

            MailMessage message = new MailMessage(sender,receiver);
            message.Subject = subject;
            message.Body = body;

            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Timeout = 2000000,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("machindranikat@gmail.com", "pyqc ctho nlnw slan")
            };
            smtp.Send(message);
        }

        public string GeneratePassword(int size)
        {
            string data = "abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            string password = "";
            Random r = new Random();
            for(int i = 1; i<size; i++)
            {
                int p = r.Next(0,data.Length-1);
                password += data[p];
            }
            return password;
        }

        public string GenerateOtp(int size)
        {
            string data = "0123456789";
            string otp = "";
            Random r = new Random();
            for(int i=1;i<size; i++)
            {
                int p = r.Next(0, data.Length - 1);
                otp += data[p];
            }
            return otp;
        }
    }
}