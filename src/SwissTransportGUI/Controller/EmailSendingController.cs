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
        public EmailSendingController()
        {

        }
        public bool SendEmail(string receiverName, string receiverEmail, string departureLocation, string departureTime, string arrivalLocation,
            string arrivalTime) {

            string _fromEmail = "swisstransportgui@mail.3n3a.ch";

            string _emailTemplate =
                $"<div><h1>Connection from {departureLocation} to {arrivalLocation}</h1><p>Departure from {departureLocation} at {departureTime} --> Arrival in {arrivalLocation} at {arrivalTime}</p></div>";

            try
            {
                // Compose a message
                MimeMessage mail = new MimeMessage();
                mail.From.Add(new MailboxAddress("SwissTransportGUI", _fromEmail));
                mail.To.Add(new MailboxAddress(receiverName, receiverEmail));
                mail.Subject = "Hello";
                mail.Body = new TextPart("html")
                {
                    Text = _emailTemplate,
                };

                // Send it!
                using (var client = new SmtpClient())
                {
                    // XXX - Should this be a little different?
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.eu.mailgun.org", 587, false);
                    //client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_fromEmail, "e0cf0378b2b6af2a459fdb6d0c5512b4-d2cc48bc-e5ffed37");

                    client.Send(mail);
                    client.Disconnect(true);
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"An Error has occurred while sending email, {e.Message}");
                throw;
            }
        }
    }
}
