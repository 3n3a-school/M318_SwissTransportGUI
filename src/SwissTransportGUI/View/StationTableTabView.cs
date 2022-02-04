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
        public TabPage StationTableTab { get; set; } = new();
        private SplitContainer TimeTableSplitContainer { get; set; } = new();
        private SplitContainer SearchBoxSplitContainer { get; set; } = new();
        private TextBox SearchBox { get; set; } = new();
        private ListBox AutoSuggestList { get; set; } = new();
        private Button SearchButton { get; set; } = new();
        private DataGridView StationTableGrid { get; set; } = new();
        private DataGridViewTextBoxColumn LineColumn { get; set; } = new();
        private DataGridViewTextBoxColumn DepartureColumn { get; set; } = new();
        private DataGridViewTextBoxColumn DirectionColumn { get; set; } = new();
        private DataGridViewTextBoxColumn PlatformColumn { get; set; } = new();
        private DataGridViewTextBoxColumn DelaysColumn { get; set; } = new();

        private DepartureBoardController StationTableController { get; }
        private StationSearch StationSearcher { get; set; }

        private string LastProcessedSearchInput { get; set; } = "";
        private Station SelectedStation { get; set; }

        public StationTableTabView()
        {
            StationSearcher = new StationSearch();
            StationTableController = new DepartureBoardController();
            SelectedStation = new Station();

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
                Text = "Departure Board",
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
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right))),
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
            // stationTableGrid & its Columns
            // 
            this.StationTableGrid = new DataGridView()
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                AllowUserToOrderColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Cursor = Cursors.Default,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(3, 2, 3, 2),
                Name = "stationTableGrid",
                ReadOnly = true,
                RowHeadersVisible = false, // weird first column
                RowHeadersWidth = 51,
                RowTemplate = {
                    Height = 29
                },
                Enabled = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
                Size = new Size(686, 215),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                TabIndex = 0,
                DataSource = StationTableController.DepartureBoardEntries,

            };
            this.LineColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Line", // Name of Field in BindingList
                HeaderText = "Line",
                Name = "LineColumn",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Width = 100,
            };
            this.DepartureColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DepartureTime", // Name of Field in BindingList
                HeaderText = "Departure",
                Name = "DepartureColumn",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            this.DirectionColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Direction", // Name of Field in BindingList
                HeaderText = "Direction",
                Name = "DirectionColumn",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            this.DelaysColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Delays", // Name of Field in BindingList
                HeaderText = "Delay",
                Name = "DelaysColumn",
            };
            this.PlatformColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Platform", // Name of Field in BindingList
                HeaderText = "Platform",
                Name = "PlatformColumn",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Width = 100,
            };

            this.StationTableGrid.Columns.AddRange(new DataGridViewColumn[] {
                this.LineColumn,
                this.DepartureColumn,
                this.DirectionColumn,
                this.PlatformColumn,
                this.DelaysColumn,
            });
            this.StationTableTab.Controls.Add(this.TimeTableSplitContainer);
            this.TimeTableSplitContainer.Panel1.Controls.Add(this.SearchBoxSplitContainer);
            this.TimeTableSplitContainer.Panel2.Controls.Add(this.StationTableGrid);
            this.SearchBoxSplitContainer.Panel1.Controls.Add(this.SearchBox);
            this.SearchBoxSplitContainer.Panel2.Controls.Add(this.SearchButton);

            // Last so it's on top
            this.StationTableTab.Controls.Add(AutoSuggestList);

            this.StationTableTab.Paint += new PaintEventHandler(this.StationTableTab_Paint);
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.GotFocus += new EventHandler(this.ShowAutoSuggestions);
            this.SearchBox.Click += new EventHandler(this.ShowAutoSuggestions);
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            this.AutoSuggestList.Click += new EventHandler(this.AutoSuggest_SuggestItem);
            this.SearchBox.KeyDown += new KeyEventHandler(this.SearchBox_HandleEnter);
        }

        private void SearchBox_HandleEnter(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(new object(), new EventArgs());
                e.Handled = true;
            }
        }

        private void AutoSuggest_SuggestItem(object? sender, EventArgs e)
        {
            Station selectedStation = (Station)AutoSuggestList.SelectedItem;
            SearchBox.Text = selectedStation.Name;
            SearchButton_Click(new object(), new EventArgs());
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string stationNameQuery = SearchBox.Text;
            if (string.IsNullOrEmpty(SelectedStation.Name) == false) {
                StationTableController.GetStationBoard(SelectedStation.Name, SelectedStation.Id);
            }
            else if (string.IsNullOrWhiteSpace(stationNameQuery) == false)
            {
                StationTableController.GetStationBoard(stationNameQuery);
            }
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

        private void StationTableTab_Paint(object sender, PaintEventArgs e)
        {
            SearchBox.Focus();
            AutoSuggestList.Width = SearchBox.Width;
        }

        private void ShowAutoSuggestions(object sender, EventArgs e)
        {
            AutoSuggestList.Show();
        }
    }
}
