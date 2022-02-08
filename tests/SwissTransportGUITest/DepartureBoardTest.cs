using System;
using SwissTransportGUI.Controller;
using FluentAssertions;
using SwissTransportGUI.Model;
using SwissTransportGUI.View.Controller;
using Xunit;

namespace SwissTransportGUITest
{
    public class DepartureBoardTest
    {
        private DepartureBoardController testee;
        public DepartureBoardTest()
        {
            this.testee = new DepartureBoardController();
        }

        [Fact]
        public void GetStationBoard()
        {
            this.testee.GetStationBoard("Luzern");
            this.testee.DepartureBoardEntries.Should().AllBeOfType<DepartureEntry>();
            this.testee.DepartureBoardEntries[0].Direction.Should().NotStartWithEquivalentOf("Luzern");
        }

        [Fact]
        public void GetStationBoardWId()
        {
            this.testee.GetStationBoard("Luzern", "8505000");
            this.testee.DepartureBoardEntries.Should().AllBeOfType<DepartureEntry>();
            this.testee.DepartureBoardEntries[0].Direction.Should().NotStartWithEquivalentOf("Luzern");
        }
    }
}