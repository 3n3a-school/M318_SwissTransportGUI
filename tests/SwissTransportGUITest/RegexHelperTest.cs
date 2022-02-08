using System;
using SwissTransportGUI.Controller;
using FluentAssertions;
using Xunit;

namespace SwissTransportGUITest
{
    public class RegexHelperTest
    {

        [Fact]
        public void IsValidEmail()
        {
            RegexHelper.IsValidEmail("clearly * and invalid=email").Should().NotBe(true);
            RegexHelper.IsValidEmail("shouldbe@valid.email").Should().Be(true);
        }
    }
}