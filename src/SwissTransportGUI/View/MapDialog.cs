using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace SwissTransportGUI.View
{
    internal class MapDialog
    {
        private Form MapForm { get; set; }
        private GMapControl MapControl { get; set; }
        private GMapOverlay MapOverlay { get; set; }
        public MapDialog()
        {
            InitControls();
        }

        private void InitControls()
        {
            MapForm = new Form();

            MapControl = new GMapControl()
            {
                Dock = DockStyle.Fill,
                MinZoom = 2, // below no data
                MaxZoom = 18,
                Zoom = 13,
                ShowCenter = false,
            };

            // 
            // Gmap Markers Overlay
            //
            this.MapOverlay = new GMapOverlay("markers");

            this.MapControl.MapProvider = OpenStreetMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            this.MapControl.SetPositionByKeywords("Schweiz");
            this.MapControl.Overlays.Add(MapOverlay);

            MapForm.Controls.Add(MapControl);
        }   
    }
}
