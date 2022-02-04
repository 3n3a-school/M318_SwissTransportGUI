using SwissTransportGUI.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransportGUI.View
{
    internal class TimetableTabView
    {
        public TabPage TimetableTab { get; set; }
        private SplitContainer splitContainer1 { get; set; }
        private TableLayoutPanel tableLayoutPanel1 { get; set; }
        private Label toLabel { get; set; }
        private TextBox toBox { get; set; }
        private Label viaLabel { get; set; }
        private TextBox fromBox { get; set; }
        private DataGridView connectionGrid { get; set; }
        private DataGridViewTextBoxColumn FromStation { get; set; }
        private DataGridViewTextBoxColumn FromStationDepartureTime { get; set; }
        private DataGridViewTextBoxColumn ToStation { get; set; }
        private DataGridViewTextBoxColumn ToStationArrivalTime { get; set; }
        private DataGridViewTextBoxColumn Duration { get; set; }
        private DataGridViewTextBoxColumn Delay { get; set; }
        private TextBox viaBox { get; set; }
        private Label fromLabel { get; set; }

        private ConnectionSearchController ConnectionController { get; set; }


        public TimetableTabView() {
            ConnectionController = new ConnectionSearchController();

            InitControls();

            connectionGrid.DataSource = ConnectionController.Connections;
            ConnectionController.GetConnections("Luzern", "Zürich");
        }

        private void InitControls()
        {
            this.TimetableTab = new TabPage();
            this.splitContainer1 = new SplitContainer();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.toLabel = new Label();
            this.toBox = new TextBox();
            this.viaLabel = new Label();
            this.viaBox = new TextBox();
            this.fromBox = new TextBox();
            this.fromLabel = new Label();
            this.connectionGrid = new DataGridView();
            this.FromStation = new DataGridViewTextBoxColumn();
            this.FromStationDepartureTime = new DataGridViewTextBoxColumn();
            this.ToStation = new DataGridViewTextBoxColumn();
            this.ToStationArrivalTime = new DataGridViewTextBoxColumn();
            this.Duration = new DataGridViewTextBoxColumn();
            this.Delay = new DataGridViewTextBoxColumn();

            // 
            // TimetableTab
            // 
            this.TimetableTab.BackColor = Color.White;
            this.TimetableTab.BackgroundImageLayout = ImageLayout.Center;
            this.TimetableTab.Controls.Add(this.splitContainer1);
            this.TimetableTab.Location = new Point(4, 24);
            this.TimetableTab.Margin = new Padding(3, 2, 3, 2);
            this.TimetableTab.Name = "TimetableTab";
            this.TimetableTab.Padding = new Padding(3, 2, 3, 2);
            this.TimetableTab.Size = new Size(692, 310);
            this.TimetableTab.TabIndex = 0;
            this.TimetableTab.Text = "Timetable";
            this.TimetableTab.Paint += new PaintEventHandler(this.TimetableTab_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = Cursors.HSplit;
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.FixedPanel = FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new Point(3, 2);
            this.splitContainer1.Margin = new Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.connectionGrid);
            this.splitContainer1.Size = new Size(686, 306);
            this.splitContainer1.SplitterDistance = 89;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.toLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.viaLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.viaBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.fromBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.fromLabel, 0, 0);
            this.tableLayoutPanel1.Location = new Point(0, 2);
            this.tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new Size(681, 85);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toLabel
            // 
            this.toLabel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Right)));
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new Point(91, 42);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new Size(19, 43);
            this.toLabel.TabIndex = 5;
            this.toLabel.Text = "To";
            this.toLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // toBox
            // 
            this.toBox.BorderStyle = BorderStyle.FixedSingle;
            this.toBox.Dock = DockStyle.Fill;
            this.toBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.toBox.Location = new Point(116, 44);
            this.toBox.Margin = new Padding(3, 2, 3, 2);
            this.toBox.Name = "toBox";
            this.toBox.PlaceholderText = "Search for a Station ...";
            this.toBox.Size = new Size(221, 29);
            this.toBox.TabIndex = 7;
            // 
            // viaLabel
            // 
            this.viaLabel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Right)));
            this.viaLabel.AutoSize = true;
            this.viaLabel.Location = new Point(427, 0);
            this.viaLabel.Name = "viaLabel";
            this.viaLabel.Size = new Size(23, 42);
            this.viaLabel.TabIndex = 1;
            this.viaLabel.Text = "Via";
            this.viaLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // viaBox
            // 
            this.viaBox.BorderStyle = BorderStyle.FixedSingle;
            this.viaBox.Dock = DockStyle.Fill;
            this.viaBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.viaBox.Location = new Point(456, 2);
            this.viaBox.Margin = new Padding(3, 2, 3, 2);
            this.viaBox.Name = "viaBox";
            this.viaBox.PlaceholderText = "Search for a Station ...";
            this.viaBox.Size = new Size(222, 29);
            this.viaBox.TabIndex = 3;
            // 
            // fromBox
            // 
            this.fromBox.BorderStyle = BorderStyle.FixedSingle;
            this.fromBox.Dock = DockStyle.Fill;
            this.fromBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.fromBox.Location = new Point(116, 2);
            this.fromBox.Margin = new Padding(3, 2, 3, 2);
            this.fromBox.Name = "fromBox";
            this.fromBox.PlaceholderText = "Search for a Station ...";
            this.fromBox.Size = new Size(221, 29);
            this.fromBox.TabIndex = 2;
            // 
            // fromLabel
            // 
            this.fromLabel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Right)));
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new Point(75, 0);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new Size(35, 42);
            this.fromLabel.TabIndex = 4;
            this.fromLabel.Text = "From";
            this.fromLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // connectionGrid
            // 
            this.connectionGrid.AllowUserToAddRows = false;
            this.connectionGrid.AllowUserToDeleteRows = false;
            this.connectionGrid.AllowUserToResizeColumns = false;
            this.connectionGrid.AllowUserToResizeRows = false;
            this.connectionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.connectionGrid.CausesValidation = false;
            this.connectionGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.connectionGrid.Columns.AddRange(new DataGridViewColumn[] {
            this.FromStation,
            this.FromStationDepartureTime,
            this.ToStation,
            this.ToStationArrivalTime,
            this.Duration,
            this.Delay});
            this.connectionGrid.Cursor = Cursors.Default;
            this.connectionGrid.Dock = DockStyle.Fill;
            this.connectionGrid.Location = new Point(0, 0);
            this.connectionGrid.Margin = new Padding(3, 2, 3, 2);
            this.connectionGrid.Name = "connectionGrid";
            this.connectionGrid.ReadOnly = true;
            this.connectionGrid.RowHeadersVisible = false;
            this.connectionGrid.RowHeadersWidth = 51;
            this.connectionGrid.RowTemplate.Height = 29;
            this.connectionGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.connectionGrid.Size = new Size(686, 214);
            this.connectionGrid.TabIndex = 0;
            // 
            // FromStation
            // 
            this.FromStation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.FromStation.DataPropertyName = "FromStation";
            this.FromStation.HeaderText = "From";
            this.FromStation.Name = "FromStation";
            this.FromStation.ReadOnly = true;
            // 
            // FromStationDepartureTime
            // 
            this.FromStationDepartureTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.FromStationDepartureTime.DataPropertyName = "FromStationDepartureTime";
            this.FromStationDepartureTime.HeaderText = "Departure";
            this.FromStationDepartureTime.Name = "FromStationDepartureTime";
            this.FromStationDepartureTime.ReadOnly = true;
            // 
            // ToStation
            // 
            this.ToStation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.ToStation.DataPropertyName = "ToStation";
            this.ToStation.HeaderText = "To";
            this.ToStation.Name = "ToStation";
            this.ToStation.ReadOnly = true;
            // 
            // ToStationArrivalTime
            // 
            this.ToStationArrivalTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.ToStationArrivalTime.DataPropertyName = "ToStationArrivalTime";
            this.ToStationArrivalTime.HeaderText = "Arrival";
            this.ToStationArrivalTime.Name = "ToStationArrivalTime";
            this.ToStationArrivalTime.ReadOnly = true;
            // 
            // Duration
            // 
            this.Duration.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Duration.DataPropertyName = "Duration";
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            // 
            // Delay
            // 
            this.Delay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Delay.DataPropertyName = "Delay";
            this.Delay.HeaderText = "Delay";
            this.Delay.Name = "Delay";
            this.Delay.ReadOnly = true;
        }

        private void TimetableTab_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
