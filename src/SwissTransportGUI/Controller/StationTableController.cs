﻿using System;
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
            // TODO: Error handling, when id null etc.
            Station chosenStation = transport.GetStations(stationName).StationList[0];
            StationBoardRoot stationBoardRoot = transport.GetStationBoard(chosenStation.Name, chosenStation.Id);

            StationBoardEntries.Clear();
            foreach (StationBoard entry in stationBoardRoot.Entries)
            {
                StationBoardEntries.Add(entry);
            }
        }
    }

}