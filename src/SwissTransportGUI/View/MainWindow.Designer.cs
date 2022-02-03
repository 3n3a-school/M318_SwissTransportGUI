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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.connectionGrid = new System.Windows.Forms.DataGridView();
            this.StationsNearbyTab = new System.Windows.Forms.TabPage();
            this.StationTableTab = new System.Windows.Forms.TabPage();
            this.TimeTableSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SearchBoxSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SearchBoxClear = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.stationTableGrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.TabControl.SuspendLayout();
            this.TimetableTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionGrid)).BeginInit();
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
            this.TabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl_Selected);
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
            this.TimetableTab.Paint += new System.Windows.Forms.PaintEventHandler(this.TimetableTab_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.connectionGrid);
            this.splitContainer1.Size = new System.Drawing.Size(786, 411);
            this.splitContainer1.SplitterDistance = 89;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(781, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(3, 67);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Search for a Station ...";
            this.textBox2.Size = new System.Drawing.Size(124, 34);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(133, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Search for a Station ...";
            this.textBox1.Size = new System.Drawing.Size(254, 34);
            this.textBox1.TabIndex = 2;
            // 
            // connectionGrid
            // 
            this.connectionGrid.AllowUserToDeleteRows = false;
            this.connectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.connectionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionGrid.Location = new System.Drawing.Point(0, 0);
            this.connectionGrid.Name = "connectionGrid";
            this.connectionGrid.ReadOnly = true;
            this.connectionGrid.RowHeadersWidth = 51;
            this.connectionGrid.RowTemplate.Height = 29;
            this.connectionGrid.Size = new System.Drawing.Size(786, 318);
            this.connectionGrid.TabIndex = 0;
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
            this.StationTableTab.Paint += new System.Windows.Forms.PaintEventHandler(this.StationTableTab_Paint);
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
            this.SearchBoxSplitContainer.Panel1.Controls.Add(this.SearchBoxClear);
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
            // SearchBoxClear
            // 
            this.SearchBoxClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.SearchBoxClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SearchBoxClear.Location = new System.Drawing.Point(518, 27);
            this.SearchBoxClear.Margin = new System.Windows.Forms.Padding(40);
            this.SearchBoxClear.Name = "SearchBoxClear";
            this.SearchBoxClear.Size = new System.Drawing.Size(37, 36);
            this.SearchBoxClear.TabIndex = 1;
            this.SearchBoxClear.Text = "X";
            this.SearchBoxClear.UseVisualStyleBackColor = true;
            this.SearchBoxClear.Click += new System.EventHandler(this.SearchBoxClear_Click);
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
            this.SearchBox.Enter += new System.EventHandler(this.SearchBox_Enter);
            this.SearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBox_KeyPress);
            this.SearchBox.Leave += new System.EventHandler(this.SearchBox_Leave);
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
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "From";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "To";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(523, 35);
            this.textBox3.Name = "textBox3";
            this.textBox3.PlaceholderText = "Search for a Station ...";
            this.textBox3.Size = new System.Drawing.Size(255, 34);
            this.textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox4.Location = new System.Drawing.Point(133, 67);
            this.textBox4.Name = "textBox4";
            this.textBox4.PlaceholderText = "Search for a Station ...";
            this.textBox4.Size = new System.Drawing.Size(254, 34);
            this.textBox4.TabIndex = 6;
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionGrid)).EndInit();
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
        private TextBox SearchBox;
        private Button SearchBoxClear;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView connectionGrid;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox4;
    }
}