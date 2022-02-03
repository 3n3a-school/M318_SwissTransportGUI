using SwissTransport.Core;
using SwissTransport.Models;

namespace SwissTransportGUI.Controller
{
    internal class StationSearch
    {
        private List<Station> Stations { get; set; }
        private ITransport Transport { get; set; }

        public StationSearch()
        {
            Stations = new List<Station>();

            Transport = new Transport();
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
    }

}
