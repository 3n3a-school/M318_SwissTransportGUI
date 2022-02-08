using System;
using System.IO;
using System.Net.Mail;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using RestSharp;
using RestSharp.Authenticators;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace SwissTransportGUI.Controller
{
    public class EmailSendingController
    {
        private readonly MailboxAddress SenderAddress = new MailboxAddress("SwissTransportGUI", "swisstransportgui@mail.3n3a.ch");
        private const string SmtpServer = "smtp.eu.mailgun.org";
        private const string SmtpPass = "e0cf0378b2b6af2a459fdb6d0c5512b4-d2cc48bc-e5ffed37";

        private MimeMessage EmailMessage { get; set; }

        private ISmtpClient SmtpClient { get; set; }

        public EmailSendingController(ISmtpClient smtpClient = null)
        {
            if (smtpClient == null)
            {
                SmtpClient = new SmtpClient();
            }
            else
            {
                SmtpClient = smtpClient;
            }
        }

        public void ConstructEmail(MailboxAddress receiverAddress, string departureLocation, string departureTime, string arrivalLocation,
            string arrivalTime)
        {
            string emailBody =
                $"<div><h1>Connection from {departureLocation} to {arrivalLocation}</h1><p>Departure from {departureLocation} at {departureTime} --> Arrival in {arrivalLocation} at {arrivalTime}</p></div>";
            string emailSubject = "Your Connection from SwissTransportGUI";

            EmailMessage = new MimeMessage();
            EmailMessage.From.Add(SenderAddress);
            EmailMessage.To.Add(receiverAddress);
            EmailMessage.Subject = emailSubject;
            EmailMessage.Body = new TextPart("html")
            {
                Text = emailBody,
            };
        }

        public bool SendMail()
        {
            try
            {
                SmtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;

                SmtpClient.Connect(SmtpServer, 587, false);
                SmtpClient.Authenticate(SenderAddress.Address, SmtpPass);

                SmtpClient.Send(EmailMessage);
                SmtpClient.Disconnect(true);

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
