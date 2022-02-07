using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using SwissTransport.Core;
using SwissTransport.Models;

namespace SwissTransportGUI.View
{
    internal class StationsNearbyView
    {
        private readonly string InitialMapLocation  = "Luzern, Schweiz";

        public TabPage StationsNearbyTab { get; set; } = new();
        private Button SearchButton { get; set; } = new ();
        private SplitContainer SearchBoxSplitContainer { get; set; } = new();
        private StationSearchComponent SearchComponent { get; set; } = new(0, 0);
        private GMapControl MapControl { get; set; } = new();
        private GMapOverlay MapMarkers { get; set; } = new();

        private ITransport transport { get; set; }

    public StationsNearbyView()
        {
            transport = new Transport();

            InitControls(); 
        }

        private void InitControls()
        {
            // 
            // StationTableTab
            // 
            this.StationsNearbyTab = new TabPage()
            {
                BackColor = Color.White,
                Location = new Point(4, 29),
                Name = "StationsNearbyTab",
                Padding = new Padding(3),
                Size = new Size(792, 417),
                TabIndex = 2,
                Text = "Stations Nearby",
            };

            // 
            // SearchBoxSplitContainer
            // 
            this.SearchBoxSplitContainer = new SplitContainer()
            {
                Cursor = Cursors.VSplit,
                Dock = DockStyle.Top,
                Location = new Point(0, 0),
                Name = "SearchBoxSplitContainer",
                Size = new Size(786, 88),
                FixedPanel = FixedPanel.Panel2, // Search Button always same size
                SplitterDistance = 580,
                TabIndex = 0,
                Panel1 = {
                    Padding = new Padding(25, 27, 0, 25),
                },
                Panel2 =
                {
                    Padding = new Padding(0, 26, 25, 31),
                }
            };


            /// StationSearch Component
            this.SearchComponent = new StationSearchComponent(25, 27);
            this.SearchComponent.SearchBox.Dock = DockStyle.Fill;

            // 
            // SearchButton
            // 
            this.SearchButton = new Button()
            {
                Cursor = Cursors.Hand,
                Dock = DockStyle.Fill,
                Enabled = false,
                Location = new Point(25, 25),
                Name = "SearchButton",
                Size = new Size(152, 38),
                TabIndex = 0,
                Text = "Search",
                UseVisualStyleBackColor = false,
            };

            //
            // GMap Map
            //
            this.MapControl = new GMapControl()
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
            this.MapMarkers = new GMapOverlay("markers");

            this.MapControl.MapProvider = OpenStreetMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            this.MapControl.SetPositionByKeywords(this.InitialMapLocation);
            this.MapControl.Overlays.Add(MapMarkers);
            

            // Adding to containers
            this.SearchBoxSplitContainer.Panel1.Controls.Add(this.SearchComponent.SearchBox);
            this.SearchBoxSplitContainer.Panel2.Controls.Add(this.SearchButton);

            this.StationsNearbyTab.Controls.Add(this.MapControl);
            this.StationsNearbyTab.Controls.Add(this.SearchBoxSplitContainer); 
            this.StationsNearbyTab.Controls.Add(this.SearchComponent.AutoSuggestList);

            // Event Handling
            this.StationsNearbyTab.Paint += new PaintEventHandler(this.StationsNearbyTab_Paint);
            this.SearchComponent.AutoSuggestList.Click += new EventHandler(this.AutoSuggest_Click);
            this.SearchComponent.SearchBox.TextChanged += new EventHandler(this.CheckInput);
            this.SearchButton.Click += new EventHandler(this.SearchButton_Click);
        }

        private void StationsNearbyTab_Paint(object? sender, PaintEventArgs e)
        {
            this.SearchComponent.SearchBox.Focus();
        }

        // TODO: Extract contents into their own functions
        private void SearchButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.SearchComponent.SelectedStation.Name) == false)
                {
                    PointLatLng newLocation = new PointLatLng((double)this.SearchComponent.SelectedStation.Coordinate.XCoordinate,
                        (double)this.SearchComponent.SelectedStation.Coordinate.YCoordinate);
                    this.MapControl.Position = newLocation;

                    MapMarkers.Clear();

                    Stations nearbyStations = transport.GetStations((double)this.SearchComponent.SelectedStation.Coordinate.XCoordinate,
                        (double)this.SearchComponent.SelectedStation.Coordinate.YCoordinate);
                    foreach (Station station in nearbyStations.StationList)
                    {
                        if (station.Coordinate.XCoordinate != null && station.Coordinate.YCoordinate != null)
                        {
                            MapControl.Zoom = 16;
                            PointLatLng newMarker = new PointLatLng((double)station.Coordinate.XCoordinate, (double)station.Coordinate.YCoordinate);
                            MapMarkers.Markers.Add(new GMarkerGoogle(newMarker, GMarkerGoogleType.red));
                            Console.WriteLine($"Marker {station.Name} X {newMarker.Lat} Y {newMarker.Lng}");
                        }
                    }
                    
                    MapMarkers.Markers.Add(new GMarkerGoogle(newLocation, GMarkerGoogleType.blue_dot));
                }
                this.SearchComponent.AutoSuggestList.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to find station. Error occurred: {ex.Message}");
            }
        }

        private void CheckInput(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.SearchComponent.SearchBox.Text) == false)
            {
                this.SearchButton.Enabled = true;
            }
            else
            {
                this.SearchButton.Enabled = false;
            }
        }

        private void AutoSuggest_Click(object? sender, EventArgs e)
        {
           SearchButton_Click(new object(), new EventArgs());
        }
    }
}
