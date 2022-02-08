using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransportGUI.Model
{
    public class DepartureEntry
    {
        public string Line { get; set; }
        public string Direction { get; set; }
        public string DepartureTime { get; set; }
        public string Delays { get; set; }
        public string Platform { get; set; }
    }
}
