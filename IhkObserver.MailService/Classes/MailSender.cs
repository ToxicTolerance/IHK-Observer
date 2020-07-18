//using IhkObserver.MailService.Interfaces;
//using IhkObserver.Observer.Classes;
//using MailKit.Net.Smtp;
//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Mail;
//using System.Text;

//namespace IhkObserver.MailService.Classes
//{
//    public class MailSender : IMailSender
//    {
//        public void SendResults(string recipientEmail, IEnumerable<SubjectMarks> results)
//        {
//            // If we use interfaces, what about di(autofac)?
//            ISmtpClientGetter smtpGetter = new GmailSmtpClientGetter();
//            ISmtpClient smtp = smtpGetter.InitializeSmtpClient();






//            CreateSmtpClient().Send(CreateMailMessage());
//            throw new NotImplementedException();
//        }

//        private MailMessage CreateMailMessage(string recipientEmail, IEnumerable<SubjectMarks> results)
//        {
//            MailMessage message = new MailMessage();
//            message.
//        }

//        private SmtpClient CreateSmtpClient()
//        {
//            SmtpClient smtp = new SmtpClient();
//        }



//    }
//}
