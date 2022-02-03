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
    internal class ConnectionSearchController
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
            => GetConnections(fromStation, toStation, _connectionDisplayLimit, DateTime.Now, DateTime.Now);

        public void GetConnections(string fromStation, string toStation, int connectionLimit, DateTime departureDate,
            DateTime departureTime)
        {
            Connections connections = Transport.GetConnections(fromStation, toStation, connectionLimit, departureDate, departureTime);
            foreach (Connection connection in connections.ConnectionList)
            {
                
                Connections.Add(new ConnectionEntry()
                {
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
