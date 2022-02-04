using SwissTransport.Core;
using SwissTransport.Models;
using System.ComponentModel;

namespace SwissTransportGUI.Controller
{
    internal class StationSearch
    {
        private List<Station> Stations { get; set; }
        private ITransport Transport { get; set; }
        public BindingList<Station> StationSuggestions { get; internal set; }

        public StationSearch()
        {
            Stations = new List<Station>();

            Transport = new Transport();

            StationSuggestions = new BindingList<Station>();
        }
        public AutoCompleteStringCollection GetStationSuggestions(string stationName)
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            Stations = Transport.GetStations(stationName).StationList;

            foreach (Station station in Stations)
            {
                autoCompleteStringCollection.Add(station.Name);
            }


            return autoCompleteStringCollection;
        }

        internal void GetNewStationSuggestions(string stationNameQuery)
        {
            StationSuggestions.Clear();
            List<Station> stations = Transport.GetStations(stationNameQuery).StationList;
            foreach(Station station in stations)
            {
                StationSuggestions.Add(station);
            }
        }
    }

}
