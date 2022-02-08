using System;
using SwissTransportGUI.Controller;
using FluentAssertions;
using MailKit.Net.Smtp;
using MimeKit;
using Moq;
using Xunit;

namespace SwissTransportGUITest
{
    public class EmailSendingtest
    {
        private EmailSendingController testee;
        public EmailSendingtest()
        {
            Mock<ISmtpClient> mockSmtpClient = new Mock<ISmtpClient>();
            this.testee = new EmailSendingController(mockSmtpClient.Object);
        }

        [Fact]
        public void ConstructEmail()
        {
            this.testee.ConstructEmail(new MailboxAddress("hans muster", "hans@muster.ch"), "Luzern", DateTime.Now.ToString(), "Zürich", DateTime.Now.AddHours(1).ToString());
            this.testee.EmailMessage.To.Count.Should().Be(1);
            this.testee.EmailMessage.From.Count.Should().Be(1);
            this.testee.EmailMessage.Subject.Should().Contain("Connection");
            this.testee.EmailMessage.HtmlBody.Should().Contain("<div>");
        }

        [Fact]
        public void SendMail()
        {
            this.testee.SendMail().Should().BeTrue();
        }
    }
}