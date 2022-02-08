using SwissTransport.Models;
using SwissTransportGUI.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransportGUI.View
{
    internal class StationSearchComponent
    {
        public TextBox SearchBox { get; set; } = new();
        public ListBox AutoSuggestList { get; private set; } = new();

        private string LastProcessedSearchInput { get; set; } = "";
        public Station SelectedStation { get; private set; }

        public StationSearch StationSearcher { get; private set; }


        /// <summary>
        /// A Component to Search for a Station, with AutoSuggestions
        /// </summary>
        /// <param name="SearchBoxX">X-Coordinate of the SearchBox</param>
        /// <param name="SearchBoxY">Y-Coordinate of the SearchBox</param>
        public StationSearchComponent(int SearchBoxX, int SearchBoxY)
        {
            StationSearcher = new StationSearch();
            SelectedStation = new Station();

            InitControls(SearchBoxX, SearchBoxY);
        }

        private void InitControls(int SearchBoxX, int SearchBoxY)
        {
            // 
            // SearchBox
            // 
            this.SearchBox = new TextBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(SearchBoxX, SearchBoxY),
                Margin = new Padding(0),
                Name = "SearchBox",
                PlaceholderText = "Search for a station ...",
                //Size = new Size(600, 34),
                TabIndex = 0,
            };

            //
            // AutoSuggestList
            //
            this.AutoSuggestList = new ListBox()
            {
                Location = new Point()
                {
                    X = SearchBox.Location.X + 3,
                    Y = SearchBox.Location.Y + SearchBox.Height + 2,
                },
                Width = SearchBox.Width,
                Visible = false,
                DataSource = StationSearcher.StationSuggestions,
                ValueMember = "Id",
                DisplayMember = "Name",
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                | AnchorStyles.Right))),
                IntegralHeight = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
            };

            this.SearchBox.TextChanged += new EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.GotFocus += new EventHandler(this.ShowAutoSuggestions);
            this.SearchBox.Click += new EventHandler(this.ShowAutoSuggestions);
            this.SearchBox.Resize += new EventHandler(this.SearchBox_Resize);
            this.SearchBox.KeyDown += new KeyEventHandler(this.SearchBox_HandleKey);
            this.AutoSuggestList.Click += new EventHandler(this.AutoSuggest_SuggestItem);
        }

        private void SearchBox_HandleKey(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AutoSuggest_SuggestItem(new object(), new EventArgs());
                e.Handled = true;
            }
        }

        private void SearchBox_Resize(object? sender, EventArgs e)
        {
            AutoSuggestList.Width = SearchBox.Width;
            AutoSuggestList.Location = new Point()
            {
                X = SearchBox.Location.X + 3,
                Y = SearchBox.Location.Y + SearchBox.Height + 2,
            };
        }

        private void AutoSuggest_SuggestItem(object? sender, EventArgs e)
        {
            Station selectedStation = (Station)AutoSuggestList.SelectedItem;
            SearchBox.Text = selectedStation.Name;
            AutoSuggestList.Hide();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string stationNameQuery = SearchBox.Text;
            if ((string.IsNullOrWhiteSpace(stationNameQuery) == false) &&
                (LastProcessedSearchInput.Length < SearchBox.Text.Length))
            {
                StationSearcher.GetNewStationSuggestions(stationNameQuery);
                SelectedStation = StationSearcher.StationSuggestions[0];
                AutoSuggestList.Show();
                AutoSuggestList.BringToFront();
            }

            if (stationNameQuery.Length < 1)
            {
                AutoSuggestList.Hide();
            }
            LastProcessedSearchInput = stationNameQuery;
        }

        private void ShowAutoSuggestions(object sender, EventArgs e)
        {
            AutoSuggestList.Show();
        }

        
    }
}
