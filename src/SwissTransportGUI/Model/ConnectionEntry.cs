using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransportGUI.Model
{
    public class ConnectionEntry
    {
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        public DateTime? FromStationDepartureTime { get; set; }
        public DateTime? ToStationArrivalTime { get; set; }
        public string Duration { get; set; }
        public int? Delay { get; set; }
    }
}
