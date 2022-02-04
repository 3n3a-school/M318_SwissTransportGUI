using SwissTransport.Models;
using SwissTransportGUI.Controller;
using SwissTransportGUI.View.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransportGUI.View
{
    internal class StationTableTabView
    {
        public TabPage StationTableTab { get; set; }
        private SplitContainer TimeTableSplitContainer { get; set; }
        private SplitContainer SearchBoxSplitContainer { get; set; }
        private TextBox SearchBox { get; set; }
        private ListBox AutoSuggestList { get; set; }
        private Button SearchButton { get; set; }
        private DataGridView dataGridView1 { get; set; }

        private string LastProcessedSearchInput { get; set; } = "";
        private StationTableController StationTableController { get; }
        private StationSearch StationSearcher { get; set; }

        public StationTableTabView()
        {
            StationSearcher = new StationSearch();
            StationTableController = new StationTableController();
            InitControls();
        }

        private void InitControls()
        {
            // 
            // StationTableTab
            // 
            this.StationTableTab = new TabPage()
            {
                BackColor = Color.White,
                Location = new Point(4, 29),
                Name = "StationTableTab",
                Padding = new Padding(3),
                Size = new Size(792, 417),
                TabIndex = 2,
                Text = "Station Table",
            };
            

            // 
            // TimeTableSplitContainer
            // 
            this.TimeTableSplitContainer = new SplitContainer()
            {
                Cursor = Cursors.HSplit,
                Dock = DockStyle.Fill,
                FixedPanel = FixedPanel.Panel1,
                Location = new Point(3, 3),
                Name = "TimeTableSplitContainer",
                Orientation = Orientation.Horizontal,
                Size = new Size(786, 411),
                SplitterDistance = 88,
                TabIndex = 1,
                Panel1 =
                {
                    BackColor = Color.White,
                },
                Panel2 =
                {
                    BackColor= Color.White,
                }
            };
            

            // 
            // SearchBoxSplitContainer
            // 
            this.SearchBoxSplitContainer = new SplitContainer()
            {
                Cursor = Cursors.VSplit,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "SearchBoxSplitContainer",
                Size = new Size(786, 88),
                SplitterDistance = 580,
                TabIndex = 0,
                Panel1 = {
                    Padding = new Padding(25, 27, 25, 25),
                },
                Panel2 =
                {
                    Padding = new Padding(25),
                }
            };
            

            // 
            // SearchBox
            // 
            this.SearchBox = new TextBox()
            {
                //AutoCompleteMode = AutoCompleteMode.Suggest,
                //AutoCompleteSource = AutoCompleteSource.CustomSource,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(25, 27),
                Margin = new Padding(20),
                Name = "SearchBox",
                PlaceholderText = "Search for a station ...",
                Size = new Size(530, 34),
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
                Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))),
                IntegralHeight = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
            };

            // 
            // SearchButton
            // 
            this.SearchButton = new Button()
            {
                Cursor = Cursors.Hand,
                Dock = DockStyle.Fill,
                Location = new Point(25, 25),
                Name = "SearchButton",
                Size = new Size(152, 38),
                TabIndex = 0,
                Text = "Search",
                UseVisualStyleBackColor = true,
            };
            

            // 
            // dataGridView1
            // 
            this.dataGridView1 = new DataGridView()
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Margin = new System.Windows.Forms.Padding(3, 2, 3, 2),
                Name = "stationTableGrid",
                ReadOnly = true,
                RowHeadersWidth = 51,
                RowTemplate = {
                    Height = 29
                },
                Size = new System.Drawing.Size(686, 215),
                TabIndex = 0,
                DataSource = StationTableController.StationBoardEntries
            };

            this.StationTableTab.Controls.Add(this.TimeTableSplitContainer);
            this.TimeTableSplitContainer.Panel1.Controls.Add(this.SearchBoxSplitContainer);
            this.TimeTableSplitContainer.Panel2.Controls.Add(this.dataGridView1);
            this.SearchBoxSplitContainer.Panel1.Controls.Add(this.SearchBox);
            this.SearchBoxSplitContainer.Panel2.Controls.Add(this.SearchButton);

            this.StationTableTab.Controls.Add(AutoSuggestList);

            this.StationTableTab.Paint += new PaintEventHandler(this.StationTableTab_Paint);
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.Click += new EventHandler(this.ShowAutoSuggestions);
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            this.AutoSuggestList.Click += new EventHandler(this.AutoSuggest_SuggestItem);
        }

        private void AutoSuggest_SuggestItem(object? sender, EventArgs e)
        {
            Station selectedStation = (Station)AutoSuggestList.SelectedItem;
            SearchBox.Text = selectedStation.Name;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string stationNameQuery = SearchBox.Text;
            if (string.IsNullOrWhiteSpace(stationNameQuery) == false)
            {
                StationTableController.GetStationBoard(stationNameQuery);
                AutoSuggestList.Hide();
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string stationNameQuery = SearchBox.Text;
            if ((string.IsNullOrWhiteSpace(stationNameQuery) == false) && (LastProcessedSearchInput.Length < SearchBox.Text.Length))
            {
                StationSearcher.GetNewStationSuggestions(stationNameQuery);
                AutoSuggestList.Visible = true;
                AutoSuggestList.BringToFront();
            }

            if (stationNameQuery.Length < 1)
            {
                AutoSuggestList.Visible = false;
            }
            LastProcessedSearchInput = stationNameQuery;
        }

        private void StationTableTab_Paint(object sender, PaintEventArgs e)
        {
            SearchBox.Focus();
            AutoSuggestList.Width = SearchBox.Width;
        }

        private void ShowAutoSuggestions(object sender, EventArgs e)
        {
            AutoSuggestList.Visible = true;
        }
    }
}
