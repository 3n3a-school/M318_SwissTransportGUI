using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using SwissTransport.Models;
using SwissTransportGUI.Model;

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
            MapForm = new Form()
            {
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(700, 400),
            };

            MapControl = new GMapControl()
            {
                Dock = DockStyle.Fill,
                MinZoom = 2, // below no data
                MaxZoom = 18,
                Zoom = 13,
                ShowCenter = false,
                MarkersEnabled = true,
            };

            // 
            // Gmap Markers Overlay
            //
            this.MapOverlay = new GMapOverlay("routes");

            this.MapControl.MapProvider = OpenStreetMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            this.MapControl.SetPositionByKeywords("Schweiz");
            this.MapControl.Overlays.Add(MapOverlay);

            MapForm.Controls.Add(MapControl);
        }

        public void AddRoute(ConnectionEntry connection)
        {
            MapOverlay.Routes.Clear();
            MapOverlay.Markers.Clear();

            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(connection.FromStationCoord);
            points.Add(connection.ToStationCoord);

            GMapRoute route = new GMapRoute(points, $"Connection from {connection.FromStation} to {connection.ToStation}");
            GMapMarker FromMarker = new GMarkerGoogle(connection.FromStationCoord, GMarkerGoogleType.green);
            GMapMarker ToMarker = new GMarkerGoogle(connection.ToStationCoord, GMarkerGoogleType.blue);

            route.Stroke = new Pen(Color.Red, 3);

            MapOverlay.Routes.Add(route);
            MapOverlay.Markers.Add(FromMarker);
            MapOverlay.Markers.Add(ToMarker);

            MapControl.Zoom = 9;
            MapControl.Position = new PointLatLng((connection.FromStationCoord.Lat + connection.ToStationCoord.Lat) / 2,
                (connection.FromStationCoord.Lng + connection.ToStationCoord.Lng) / 2); // Middle point

        }

        public void Show()
        {
            MapForm.ShowDialog();
        }
    }
}
