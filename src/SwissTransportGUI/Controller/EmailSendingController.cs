using System;
using System.Buffers.Text;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace SwissTransportGUI.Controller
{
    public class EmailSendingController
    {
        private string a = "cwB3AGkAcwBzAHQAcgBhAG4AcwBwAG8AcgB0AGcAdQBpAEAAbQBhAGkAbAAuADMAbgAzAGEALgBjAGgA";
        private string b = "cwBtAHQAcAAuAGUAdQAuAG0AYQBpAGwAZwB1AG4ALgBvAHIAZwA=";
        private string c = "ZQAwAGMAZgAwADMANwA4AGIAMgBiADYAYQBmADIAYQA0ADUAOQBmAGQAYgA2AGQAMABjADUANQAxADIAYgA0AC0AZAAyAGMAYwA0ADgAYgBjAC0AZQA1AGYAZgBlAGQAMwA3AA==";
        private MailboxAddress SenderAddress { get; set; }
        private string SmtpServer { get; set; }
        private string SmtpPass { get; set; }

        public MimeMessage EmailMessage { get; set; }

        private ISmtpClient SmtpClient { get; set; }

        public EmailSendingController(ISmtpClient smtpClient)
        {
            SmtpClient = smtpClient;

            SenderAddress = new MailboxAddress("SwissTransportGUI", Encoding.Unicode.GetString(Convert.FromBase64String(a)));
            SmtpServer = Encoding.Unicode.GetString(Convert.FromBase64String(b));
            SmtpPass = Encoding.Unicode.GetString(Convert.FromBase64String(c));
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
