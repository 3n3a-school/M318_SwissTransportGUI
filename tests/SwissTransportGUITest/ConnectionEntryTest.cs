using System;
using SwissTransportGUI.Model;
using FluentAssertions;
using GMap.NET;
using Xunit;

namespace SwissTransportGUITest
{
    public class ConnectionEntryTest
    {

        [Fact]
        public void ConnectionEntry()
        {
            ConnectionEntry test1 = new ConnectionEntry()
            {
                Duration = "30.05M",
                FromStation = "Zürich",
                FromStationDepartureTime = DateTime.Now,
                ToStation = "luzern",
                ToStationArrivalTime = DateTime.Now.AddHours(2),
                FromStationCoord = new PointLatLng(0, 0),
                ToStationCoord = new PointLatLng(20, 20),
            };
            test1.Should().BeOfType<ConnectionEntry>();
        }
    }
}