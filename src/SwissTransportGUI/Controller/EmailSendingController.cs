using System;
using System.IO;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using RestSharp;
using RestSharp.Authenticators;

namespace SwissTransportGUI.Controller
{
    internal class EmailSendingController
    {
        private const string SenderName = "SwissTransportGUI";
        private const string FromEmail = "swisstransportgui@mail.3n3a.ch";
        private const string SmtpServer = "smtp.eu.mailgun.org";
        private const string SmtpPass = "e0cf0378b2b6af2a459fdb6d0c5512b4-d2cc48bc-e5ffed37";

        public EmailSendingController()
        {

        }
        public bool SendEmail(string receiverName, string receiverEmail, string departureLocation, string departureTime, string arrivalLocation,
            string arrivalTime)
        {
            string _emailTemplate =
                $"<div><h1>Connection from {departureLocation} to {arrivalLocation}</h1><p>Departure from {departureLocation} at {departureTime} --> Arrival in {arrivalLocation} at {arrivalTime}</p></div>";
            string _emailSubject = "Your Connection from SwissTransportGUI";

            try
            {
                MimeMessage mail = new MimeMessage();
                mail.From.Add(new MailboxAddress(SenderName, FromEmail));
                mail.To.Add(new MailboxAddress(receiverName, receiverEmail));
                mail.Subject = _emailSubject;
                mail.Body = new TextPart("html")
                {
                    Text = _emailTemplate,
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(SmtpServer, 587, false);
                    //client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(FromEmail, SmtpPass);

                    client.Send(mail);
                    client.Disconnect(true);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An Error has occurred while sending email, {e.Message}");
                return false;
            }
        }
    }
}
