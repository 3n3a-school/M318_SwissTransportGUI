using System;
using SwissTransportGUI.Controller;
using FluentAssertions;
using Xunit;

namespace SwissTransportGUITest
{
    public class StationSearchTest
    {
        private StationSearch testee;
        public StationSearchTest()
        {
            this.testee = new StationSearch();
        }

        [Fact]
        public void GetStationSuggestions()
        {
            this.testee.GetNewStationSuggestions("Luzern");
            this.testee.StationSuggestions[0].Name.Should().Contain("Luzern");
        }
    }
}