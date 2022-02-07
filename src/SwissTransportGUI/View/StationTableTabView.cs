using SwissTransport.Models;
using SwissTransportGUI.Controller;
using SwissTransportGUI.View.Controller;

namespace SwissTransportGUI.View
{
    internal class StationTableTabView
    {
        public TabPage StationTableTab { get; set; } = new();
        private SplitContainer TimeTableSplitContainer { get; set; } = new();
        private SplitContainer SearchBoxSplitContainer { get; set; } = new();
        private Button SearchButton { get; set; } = new();
        private DataGridView StationTableGrid { get; set; } = new();
        private DataGridViewTextBoxColumn LineColumn { get; set; } = new();
        private DataGridViewTextBoxColumn DepartureColumn { get; set; } = new();
        private DataGridViewTextBoxColumn DirectionColumn { get; set; } = new();
        private DataGridViewTextBoxColumn PlatformColumn { get; set; } = new();
        private DataGridViewTextBoxColumn DelaysColumn { get; set; } = new();
        private StationSearchComponent SearchComponent { get; set; } = new(0, 0);

        private DepartureBoardController StationTableController { get; }

        public StationTableTabView()
        {
            StationTableController = new DepartureBoardController();

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
            this.SearchBoxSplitContainer.Panel1.Controls.Add(this.SearchComponent.SearchBox);
            this.SearchBoxSplitContainer.Panel2.Controls.Add(this.SearchButton);

            // Last so it's on top
            this.StationTableTab.Controls.Add(this.SearchComponent.AutoSuggestList);

            this.StationTableTab.Paint += new PaintEventHandler(this.StationTableTab_Paint);
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            this.SearchComponent.AutoSuggestList.Click += new EventHandler(this.AutoSuggest_Click);
            this.SearchComponent.SearchBox.TextChanged += new EventHandler(this.CheckInput);
        }

        private void CheckInput(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.SearchComponent.SearchBox.Text) == false)
            {
                this.SearchButton.Enabled = true;
            } else
            {
                this.SearchButton.Enabled = false;
            }
        }

        private void AutoSuggest_Click(object? sender, EventArgs e)
        {
            SearchButton_Click(new object(), new EventArgs());
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string stationNameQuery = this.SearchComponent.SearchBox.Text;
                if (string.IsNullOrEmpty(this.SearchComponent.SelectedStation.Name) == false)
                {
                    StationTableController.GetStationBoard(this.SearchComponent.SelectedStation.Name, this.SearchComponent.SelectedStation.Id);
                }
                else if (string.IsNullOrWhiteSpace(stationNameQuery) == false)
                {
                    StationTableController.GetStationBoard(stationNameQuery);
                }
                this.SearchComponent.AutoSuggestList.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Departure Board failed to load. Error occurred: {ex.Message}");
            }
            
        }

        private void StationTableTab_Paint(object sender, PaintEventArgs e)
        {
            this.SearchComponent.SearchBox.Focus();
            
        }
    }
}
