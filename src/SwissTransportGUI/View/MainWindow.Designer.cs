namespace SwissTransportGUI.View
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TimetableTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.StationsNearbyTab = new System.Windows.Forms.TabPage();
            this.StationTableTab = new System.Windows.Forms.TabPage();
            this.TimeTableSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SearchBoxSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.stationTableGrid = new System.Windows.Forms.DataGridView();
            this.TabControl.SuspendLayout();
            this.TimetableTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.StationTableTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeTableSplitContainer)).BeginInit();
            this.TimeTableSplitContainer.Panel1.SuspendLayout();
            this.TimeTableSplitContainer.Panel2.SuspendLayout();
            this.TimeTableSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBoxSplitContainer)).BeginInit();
            this.SearchBoxSplitContainer.Panel1.SuspendLayout();
            this.SearchBoxSplitContainer.Panel2.SuspendLayout();
            this.SearchBoxSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationTableGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TimetableTab);
            this.TabControl.Controls.Add(this.StationsNearbyTab);
            this.TabControl.Controls.Add(this.StationTableTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(800, 450);
            this.TabControl.TabIndex = 0;
            // 
            // TimetableTab
            // 
            this.TimetableTab.BackColor = System.Drawing.Color.White;
            this.TimetableTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TimetableTab.Controls.Add(this.splitContainer1);
            this.TimetableTab.Location = new System.Drawing.Point(4, 29);
            this.TimetableTab.Name = "TimetableTab";
            this.TimetableTab.Padding = new System.Windows.Forms.Padding(3);
            this.TimetableTab.Size = new System.Drawing.Size(792, 417);
            this.TimetableTab.TabIndex = 0;
            this.TimetableTab.Text = "Timetable";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Size = new System.Drawing.Size(786, 411);
            this.splitContainer1.SplitterDistance = 89;
            this.splitContainer1.TabIndex = 0;
            // 
            // StationsNearbyTab
            // 
            this.StationsNearbyTab.BackColor = System.Drawing.Color.White;
            this.StationsNearbyTab.Location = new System.Drawing.Point(4, 29);
            this.StationsNearbyTab.Name = "StationsNearbyTab";
            this.StationsNearbyTab.Padding = new System.Windows.Forms.Padding(3);
            this.StationsNearbyTab.Size = new System.Drawing.Size(792, 417);
            this.StationsNearbyTab.TabIndex = 1;
            this.StationsNearbyTab.Text = "Stations Nearby";
            // 
            // StationTableTab
            // 
            this.StationTableTab.BackColor = System.Drawing.Color.White;
            this.StationTableTab.Controls.Add(this.TimeTableSplitContainer);
            this.StationTableTab.Location = new System.Drawing.Point(4, 29);
            this.StationTableTab.Name = "StationTableTab";
            this.StationTableTab.Padding = new System.Windows.Forms.Padding(3);
            this.StationTableTab.Size = new System.Drawing.Size(792, 417);
            this.StationTableTab.TabIndex = 2;
            this.StationTableTab.Text = "Station Table";
            // 
            // TimeTableSplitContainer
            // 
            this.TimeTableSplitContainer.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.TimeTableSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeTableSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.TimeTableSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.TimeTableSplitContainer.Name = "TimeTableSplitContainer";
            this.TimeTableSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // TimeTableSplitContainer.Panel1
            // 
            this.TimeTableSplitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.TimeTableSplitContainer.Panel1.Controls.Add(this.SearchBoxSplitContainer);
            // 
            // TimeTableSplitContainer.Panel2
            // 
            this.TimeTableSplitContainer.Panel2.Controls.Add(this.stationTableGrid);
            this.TimeTableSplitContainer.Size = new System.Drawing.Size(786, 411);
            this.TimeTableSplitContainer.SplitterDistance = 88;
            this.TimeTableSplitContainer.TabIndex = 1;
            // 
            // SearchBoxSplitContainer
            // 
            this.SearchBoxSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.SearchBoxSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchBoxSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SearchBoxSplitContainer.Name = "SearchBoxSplitContainer";
            // 
            // SearchBoxSplitContainer.Panel1
            // 
            this.SearchBoxSplitContainer.Panel1.Controls.Add(this.SearchBox);
            this.SearchBoxSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(25, 27, 25, 25);
            // 
            // SearchBoxSplitContainer.Panel2
            // 
            this.SearchBoxSplitContainer.Panel2.Controls.Add(this.SearchButton);
            this.SearchBoxSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(25);
            this.SearchBoxSplitContainer.Size = new System.Drawing.Size(786, 88);
            this.SearchBoxSplitContainer.SplitterDistance = 580;
            this.SearchBoxSplitContainer.TabIndex = 0;
            // 
            // SearchBox
            // 
            this.SearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SearchBox.Location = new System.Drawing.Point(25, 27);
            this.SearchBox.Margin = new System.Windows.Forms.Padding(20);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.PlaceholderText = "  Search for a station ...";
            this.SearchBox.Size = new System.Drawing.Size(530, 34);
            this.SearchBox.TabIndex = 0;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyUp);
            // 
            // SearchButton
            // 
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchButton.Location = new System.Drawing.Point(25, 25);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(152, 38);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // stationTableGrid
            // 
            this.stationTableGrid.AllowUserToAddRows = false;
            this.stationTableGrid.AllowUserToDeleteRows = false;
            this.stationTableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stationTableGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stationTableGrid.Location = new System.Drawing.Point(0, 0);
            this.stationTableGrid.Name = "stationTableGrid";
            this.stationTableGrid.ReadOnly = true;
            this.stationTableGrid.RowHeadersWidth = 51;
            this.stationTableGrid.RowTemplate.Height = 29;
            this.stationTableGrid.Size = new System.Drawing.Size(786, 319);
            this.stationTableGrid.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabControl);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.TabControl.ResumeLayout(false);
            this.TimetableTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.StationTableTab.ResumeLayout(false);
            this.TimeTableSplitContainer.Panel1.ResumeLayout(false);
            this.TimeTableSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TimeTableSplitContainer)).EndInit();
            this.TimeTableSplitContainer.ResumeLayout(false);
            this.SearchBoxSplitContainer.Panel1.ResumeLayout(false);
            this.SearchBoxSplitContainer.Panel1.PerformLayout();
            this.SearchBoxSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchBoxSplitContainer)).EndInit();
            this.SearchBoxSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stationTableGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl TabControl;
        private TabPage StationsNearbyTab;
        private TabPage StationTableTab;
        private TabPage TimetableTab;
        private SplitContainer TimeTableSplitContainer;
        private SplitContainer SearchBoxSplitContainer;
        private Button SearchButton;
        private DataGridView stationTableGrid;
        private SplitContainer splitContainer1;
        private TextBox SearchBox;
    }
}