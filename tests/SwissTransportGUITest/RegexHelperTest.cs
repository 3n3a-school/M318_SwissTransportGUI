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
            RegexHelper.IsValidEmail("clearly * and invalid=email").Should().BeFalse();
            RegexHelper.IsValidEmail("shouldbe@valid.email").Should().BeTrue();
        }

        [Fact]
        public void IsValidSearchQuery()
        {
            RegexHelper.IsValidSearchQuery("**ç, Luzern").Should().BeFalse();
            RegexHelper.IsValidSearchQuery("Luzern, Bahnhof").Should().BeTrue();
            RegexHelper.IsValidSearchQuery("Luzern, Bahnhof").Should().BeTrue();
        }
    }
}