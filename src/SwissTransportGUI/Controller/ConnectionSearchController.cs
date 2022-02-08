using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        public void GetConnections(string fromStation, string toStation) 
            => GetConnections(fromStation, toStation, DateTime.Now, DateTime.Now);

        public void GetConnections(string fromStation, string toStation, DateTime departureDate,
            DateTime departureTime)
        {
            Connections.Clear();
            Connections connections = Transport.GetConnections(fromStation, toStation, _connectionDisplayLimit, departureDate, departureTime);
            foreach (Connection connection in connections.ConnectionList)
            {
                Connections.Add(new ConnectionEntry()
                {
                    FromStationCoord = connection.From.Station.Coordinate,
                    ToStationCoord = connection.To.Station.Coordinate,
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
