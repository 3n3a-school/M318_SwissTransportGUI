using System;

namespace SwissTransport
{
    using FluentAssertions;
    using SwissTransport.Core;
    using SwissTransport.Models;
    using Xunit;

    public class TransportTest
    {
        private readonly ITransport testee;

        public TransportTest()
        {
            this.testee = new Transport();
        }

        [Fact]
        public void Locations()
        {
            Stations stations = this.testee.GetStations("Sursee,");

            stations.StationList.Should().HaveCount(10);
        }

        [Fact]
        public void LocationsByCoords()
        {
            Stations stations = this.testee.GetStations(47.05048, 8.30635);
            stations.StationList.Should().HaveCount(10);
        }

        [Fact]
        public void StationBoard()
        {
            StationBoardRoot stationBoard = this.testee.GetStationBoard("Sursee", "8502007");

            stationBoard.Should().NotBeNull();
        }

        [Fact]
        public void Connections()
        {
            Connections connections = this.testee.GetConnections("Sursee", "Luzern", 4, DateTime.Now, DateTime.Now, null);

            connections.Should().NotBeNull();
            connections.ConnectionList.Count.Should().Be(4);
            connections.ConnectionList[0].From.Departure.Should().BeAfter(DateTime.Now);
        }

        [Fact]
        public void ConnectionsWVia()
        {
            Connections connections = this.testee.GetConnections("Sursee", "Luzern", 4, DateTime.Now, DateTime.Now, "Lausanne");

            connections.Should().NotBeNull();
            connections.ConnectionList.Count.Should().Be(4);
            connections.ConnectionList[0].From.Departure.Should().BeAfter(DateTime.Now);
        }
    }
}