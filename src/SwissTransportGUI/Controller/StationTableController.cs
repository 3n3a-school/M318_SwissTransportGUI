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
        
        public AutoCompleteStringCollection GetStationSuggestions(string stationName)
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();

            foreach (Station station in transport.GetStations(stationName).StationList)
            {
                autoCompleteStringCollection.Add(station.Name);
            }


            return autoCompleteStringCollection;
        }
    }

}
