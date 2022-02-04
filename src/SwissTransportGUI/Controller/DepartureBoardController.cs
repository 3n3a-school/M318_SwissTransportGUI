using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport.Core;
using SwissTransport.Models;
using SwissTransportGUI.Model;

namespace SwissTransportGUI.View.Controller
{
    internal class DepartureBoardController
    {
        public BindingList<DepartureEntry> DepartureBoardEntries { get; set; }
        private ITransport transport { get; set; }

        public DepartureBoardController()
        {
            DepartureBoardEntries = new BindingList<DepartureEntry>();

            transport = new Transport();
        }

        public void GetStationBoard(string stationName)
        {
            Station chosenStation = transport.GetStations(stationName).StationList[0];
            GetStationBoard(chosenStation.Name, chosenStation.Id);
        }

        public void GetStationBoard(string stationName, string stationId)
        {
            // TODO: Error handling, when id null etc.
            StationBoardRoot stationBoardRoot = transport.GetStationBoard(stationName, stationId);

            DepartureBoardEntries.Clear();
            foreach (StationBoard entry in stationBoardRoot.Entries)
            {
                DepartureBoardEntries.Add(new DepartureEntry()
                {
                    Line = $"{entry.Category}{entry.Number}",
                    DepartureTime = entry.Stop.Departure.ToString("HH:mm"),
                    Direction = entry.To
                });
            }
        }
    }

}
