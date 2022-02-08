using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using SwissTransport.Core;
using SwissTransport.Models;
using SwissTransportGUI.Model;

namespace SwissTransportGUI.Controller
{
    public class ConnectionSearchController
    {
        private ITransport Transport { get; set; }
        private static readonly int _connectionDisplayLimit = 4;

        public BindingList<ConnectionEntry> Connections { get; set; }

        public ConnectionSearchController()
        {
            Transport = new Transport();
            Connections = new BindingList<ConnectionEntry>();
        }

        public void GetConnections(string fromStation, string toStation, string viaStation = null) 
            => GetConnections(fromStation, toStation, DateTime.Now, DateTime.Now, viaStation);

        public void GetConnections(string fromStation, string toStation, DateTime departureDate,
            DateTime departureTime, string viaStation = null)
        {
            Connections.Clear();
            Connections connections = Transport.GetConnections(fromStation, toStation, _connectionDisplayLimit, departureDate, departureTime, viaStation);
            foreach (Connection connection in connections.ConnectionList)
            {
                Connections.Add(new ConnectionEntry()
                {
                    FromStationCoord = new PointLatLng((double)connection.From.Station.Coordinate.XCoordinate, (double)connection.From.Station.Coordinate.YCoordinate),
                    ToStationCoord = new PointLatLng((double)connection.To.Station.Coordinate.XCoordinate, (double)connection.To.Station.Coordinate.YCoordinate),
                    FromStation = connection.From.Station.Name,
                    ToStation = connection.To.Station.Name,
                    FromStationDepartureTime = connection.From.Departure,
                    ToStationArrivalTime = connection.To.Arrival,
                    Duration = connection.Duration,
                    Delay = connection.To.Delay
                });
            }
        }
    }
}
