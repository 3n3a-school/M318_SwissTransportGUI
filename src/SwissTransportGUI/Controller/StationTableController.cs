using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport.Core;
using SwissTransport.Models;

namespace SwissTransportGUI.View.Controller
{
    internal class StationTableController
    {
        public BindingList<StationBoard> StationBoardEntries { get; set; }
        private ITransport transport { get; set; }

        public StationTableController()
        {
            StationBoardEntries = new BindingList<StationBoard>();

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

            StationBoardEntries.Clear();
            foreach (StationBoard entry in stationBoardRoot.Entries)
            {
                StationBoardEntries.Add(entry);
            }
        }
    }

}
