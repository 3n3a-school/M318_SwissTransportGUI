using SwissTransportGUI.Controller;

namespace SwissTransportGUI.View
{
    internal class TimetableTabView
    {
        public TabPage TimetableTab { get; set; } = new();
        private SplitContainer splitContainer1 { get; set; } = new();
        private TableLayoutPanel tableLayoutPanel1 { get; set; } = new();
        private Label toLabel { get; set; } = new();
        private TextBox toBox { get; set; } = new();
        private Label viaLabel { get; set; } = new();
        private TextBox fromBox { get; set; } = new();
        private DataGridView connectionGrid { get; set; } = new();
        private DataGridViewTextBoxColumn FromStation { get; set; } = new();
        private DataGridViewTextBoxColumn FromStationDepartureTime { get; set; } = new();
        private DataGridViewTextBoxColumn ToStation { get; set; } = new();
        private DataGridViewTextBoxColumn ToStationArrivalTime { get; set; } = new();
        private DataGridViewTextBoxColumn Duration { get; set; } = new();
        private DataGridViewTextBoxColumn Delay { get; set; } = new();
        private TextBox viaBox { get; set; } = new();
        private Label fromLabel { get; set; } = new();

        private ConnectionSearchController ConnectionController { get; set; }


        public TimetableTabView() {
            ConnectionController = new ConnectionSearchController();

            InitControls();

            connectionGrid.DataSource = ConnectionController.Connections;
            ConnectionController.GetConnections("Luzern", "Zürich");
        }

        private void InitControls()
        {
            // 
            // TimetableTab
            // 
            this.TimetableTab = new TabPage()
            {
                BackColor = Color.White,
                BackgroundImageLayout = ImageLayout.Center,
                Location = new Point(4, 24),
                Margin = new Padding(3, 2, 3, 2),
                Name = "TimetableTab",
                Padding = new Padding(3, 2, 3, 2),
                Size = new Size(692, 310),
                TabIndex = 0,
                Text = "Timetable",
            };
            

            // 
            // splitContainer1
            // 
            this.splitContainer1 = new SplitContainer()
            {
                Cursor = Cursors.HSplit,
                Dock = DockStyle.Fill,
                FixedPanel = FixedPanel.Panel1,
                IsSplitterFixed = true,
                Location = new Point(3, 2),
                Margin = new Padding(3, 2, 3, 2),
                Name = "splitContainer1",
                Orientation = Orientation.Horizontal,
                Panel1 =
                {
                    BackColor = Color.White
                },
                Size = new Size(686, 306),
                SplitterDistance = 89,
                SplitterWidth = 3,
                TabIndex = 0,
            };

            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1 = new TableLayoutPanel()
            {
                Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                    | AnchorStyles.Left)
                    | AnchorStyles.Right))),
                ColumnCount = 4,
                Location = new Point(0, 2),
                Margin = new Padding(3, 2, 3, 2),
                Name = "tableLayoutPanel1",
                RowCount = 2,
                Size = new Size(681, 85),
                TabIndex = 0,
            };
            // 
            // toLabel
            // 
            this.toLabel = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(91, 42),
                Name = "toLabel",
                Size = new Size(19, 43),
                TabIndex = 5,
                Text = "To",
                TextAlign = ContentAlignment.MiddleCenter,
            };

            // 
            // toBox
            // 
            this.toBox = new TextBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(116, 44),
                Margin = new Padding(3, 2, 3, 2),
                Name = "toBox",
                PlaceholderText = "Search for a Station ...",
                Size = new Size(221, 29),
                TabIndex = 7,
            };

            // 
            // viaLabel
            // 
            this.viaLabel = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(427, 0),
                Name = "viaLabel",
                Size = new Size(23, 42),
                TabIndex = 1,
                Text = "Via",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            

            // 
            // viaBox
            // 
            this.viaBox = new TextBox()
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(456, 2),
                Margin = new Padding(3, 2, 3, 2),
                Name = "viaBox",
                PlaceholderText = "Search for a Station ...",
                Size = new Size(222, 29),
                TabIndex = 3,
            };
            

            // 
            // fromBox
            // 
            this.fromBox = new TextBox() { 
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(116, 2),
                Margin = new Padding(3, 2, 3, 2),
                Name = "fromBox",
                PlaceholderText = "Search for a Station ...",
                Size = new Size(221, 29),
                TabIndex = 2,
            };

            // 
            // fromLabel
            // 
            this.fromLabel = new Label() { 
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(75, 0),
                Name = "fromLabel",
                Size = new Size(35, 42),
                TabIndex = 4,
                Text = "From",
                TextAlign = ContentAlignment.MiddleCenter,
            };

            // 
            // connectionGrid
            // 
            this.connectionGrid = new DataGridView() { 
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                CausesValidation = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Cursor = Cursors.Default,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Margin = new Padding(3, 2, 3, 2),
                Name = "connectionGrid",
                ReadOnly = true,
                RowHeadersVisible = false,
                RowHeadersWidth = 51,
                RowTemplate = { Height = 29, },
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = new Size(686, 214),
                TabIndex = 0,
            };


            // 
            // FromStation
            // 
            this.FromStation = new DataGridViewTextBoxColumn() { 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "FromStation",
                HeaderText = "From",
                Name = "FromStation",
                ReadOnly = true,
            };

            // 
            // FromStationDepartureTime
            // 
            this.FromStationDepartureTime = new DataGridViewTextBoxColumn() { 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "FromStationDepartureTime",
                HeaderText = "Departure",
                Name = "FromStationDepartureTime",
                ReadOnly = true,
            };

            // 
            // ToStation
            // 
            this.ToStation = new DataGridViewTextBoxColumn() { 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "ToStation",
                HeaderText = "To",
                Name = "ToStation",
                ReadOnly = true,
            };

            // 
            // ToStationArrivalTime
            // 
            this.ToStationArrivalTime = new DataGridViewTextBoxColumn() { 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "ToStationArrivalTime",
                HeaderText = "Arrival",
                Name = "ToStationArrivalTime",
                ReadOnly = true,
            };

            // 
            // Duration
            // 
            this.Duration = new DataGridViewTextBoxColumn() { 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Duration",
                HeaderText = "Duration",
                Name = "Duration",
                ReadOnly = true,
            };

            // 
            // Delay
            // 
            this.Delay = new DataGridViewTextBoxColumn() { 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Delay",
                HeaderText = "Delay",
                Name = "Delay",
                ReadOnly = true,
            };
            
            // Adding Elements to Containers
            this.TimetableTab.Controls.Add(this.splitContainer1);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.connectionGrid);
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.toLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.viaLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.viaBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.fromBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.fromLabel, 0, 0);
            this.connectionGrid.Columns.AddRange(new DataGridViewColumn[] {
                this.FromStation,
                this.FromStationDepartureTime,
                this.ToStation,
                this.ToStationArrivalTime,
                this.Duration,
                this.Delay
            });


            // Initializing Event Handlers
            this.TimetableTab.Paint += new PaintEventHandler(this.TimetableTab_Paint);
        }

        private void TimetableTab_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
