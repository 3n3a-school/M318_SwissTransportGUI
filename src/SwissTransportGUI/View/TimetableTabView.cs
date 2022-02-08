using MailKit.Net.Smtp;
using MimeKit;
using SwissTransportGUI.Controller;
using SwissTransportGUI.Model;

namespace SwissTransportGUI.View
{
    internal class TimetableTabView
    {
        public TabPage TimetableTab { get; set; } = new();
        private SplitContainer SplitContainer1 { get; set; } = new();
        private TableLayoutPanel TableLayoutPanel1 { get; set; } = new();
        private Label ToLabel { get; set; } = new();
        private Label ViaLabel { get; set; } = new();
        private StationSearchComponent ToBox { get; set; } = new(0,0);
        private StationSearchComponent FromBox { get; set; } = new(0,0);
        private StationSearchComponent ViaBox { get; set; } = new(0,0);
        private DataGridView ConnectionGrid { get; set; } = new();
        private DataGridViewTextBoxColumn FromStation { get; set; } = new();
        private DataGridViewTextBoxColumn FromStationDepartureTime { get; set; } = new();
        private DataGridViewTextBoxColumn ToStation { get; set; } = new();
        private DataGridViewTextBoxColumn ToStationArrivalTime { get; set; } = new();
        private DataGridViewTextBoxColumn Duration { get; set; } = new();
        private DataGridViewTextBoxColumn Delay { get; set; } = new();
        private DataGridViewTextBoxColumn FromCoord { get; set; }
        private DataGridViewTextBoxColumn ToCoord { get; set; }
        private Label FromLabel { get; set; } = new();
        private Label DateLabel { get; set; } = new();
        private Label TimeLabel { get; set; } = new();
        private DateTimePicker DatePicker { get; set; } = new();
        private DateTimePicker TimePicker { get; set; } = new();
        private Button SearchButton { get; set; } = new();
        private TableLayoutPanel AdditionalButtonLayoutPanel { get; set; } = new();
        private Button ViewMapButton { get; set; } = new();
        private Button ShareByEmail { get; set; } = new ();

        private MapDialog MapDialog { get; set; }

        private ConnectionSearchController ConnectionController { get; set; }
        private EmailSendingController EmailSendingController { get; set; }
        private bool DatePickerFilledOut { get; set; } = false;
        private bool TimePickerFilledOut { get; set; } = false;
        private bool ViaBoxFilledOut { get; set; } = false;
        private ConnectionEntry SelectedConnection { get; set; } = new();

        public TimetableTabView() {
            ConnectionController = new ConnectionSearchController();
            EmailSendingController = new EmailSendingController(new SmtpClient());
            MapDialog = new MapDialog();

            InitControls();

            ConnectionGrid.DataSource = ConnectionController.Connections;
        }

        private void InitControls()
        {
            Font searchBoxFont = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);

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
            // SplitContainer1
            // 
            this.SplitContainer1 = new SplitContainer()
            {
                Cursor = Cursors.Default,
                Dock = DockStyle.Fill,
                FixedPanel = FixedPanel.Panel1,
                IsSplitterFixed = true,
                Location = new Point(3, 2),
                Margin = new Padding(3, 2, 3, 2),
                Name = "SplitContainer1",
                Orientation = Orientation.Horizontal,
                Panel1 =
                {
                    BackColor = Color.White
                },
                Size = new Size(686, 306),
                SplitterDistance = 125,
                SplitterWidth = 3,
                TabIndex = 0,
            };

            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1 = new TableLayoutPanel()
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Top,
                Dock = DockStyle.Fill,
                ColumnCount = 5,
                Location = new Point(0, 0),
                Margin = new Padding(3, 2, 3, 2),
                Name = "TableLayoutPanel1",
                RowCount = 3,
                //Size = new Size(681, 85),
                TabIndex = 0,
            };
            // 
            // ToLabel
            // 
            this.ToLabel = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(91, 42),
                Name = "ToLabel",
                Size = new Size(19, 43),
                TabIndex = 5,
                Text = "To",
                TextAlign = ContentAlignment.MiddleCenter,
            };

            // 
            // ToBox
            // 
            this.ToBox = new StationSearchComponent(116, 44);
            this.ToBox.SearchBox.Margin = new Padding(0);
            this.ToBox.SearchBox.Font = searchBoxFont;

            // 
            // viaLabel
            // 
            this.ViaLabel = new Label()
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
            this.ViaBox = new StationSearchComponent(456, 2);
            this.ViaBox.SearchBox.Margin = new Padding(0);
            this.ViaBox.SearchBox.Font = searchBoxFont;


            // 
            // fromBox
            // 
            this.FromBox = new StationSearchComponent(116, 2);
            this.FromBox.SearchBox.Margin = new Padding(0);
            this.FromBox.SearchBox.Font = searchBoxFont;

            // 
            // fromLabel
            // 
            this.FromLabel = new Label() {
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
            // DateLabel
            // 
            this.DateLabel = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(427, 0),
                Name = "DateLabel",
                Size = new Size(23, 42),
                TabIndex = 1,
                Text = "Date",
                TextAlign = ContentAlignment.MiddleCenter,
            };

            // 
            // TimeLabel
            // 
            this.TimeLabel = new Label()
            {
                Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right))),
                AutoSize = true,
                Location = new Point(427, 0),
                Name = "TimeLabel",
                Size = new Size(23, 42),
                TabIndex = 1,
                Text = "Time",
                TextAlign = ContentAlignment.MiddleCenter,
            };

            //
            // DatePicker
            //
            this.DatePicker = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(0,0),
                MaxDate = DateTime.Today.AddDays(14), // in 2 Weeks
                MinDate = DateTime.Today,
                Value = DateTime.Today,
                Anchor = AnchorStyles.Right | AnchorStyles.Left,
            };

            //
            // TimePicker
            //
            this.TimePicker = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Time,
                Location = new Point(0, 0),
                ShowUpDown = true,
                MaxDate = new DateTime(2022, 1, 1, 23, 59, 59),
                MinDate = new DateTime(2022, 1, 1, 0, 0, 0),
                Value = new DateTime(2022, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                Anchor = AnchorStyles.Right | AnchorStyles.Left,
            };

            // 
            // AdditionalButtonLayoutPanel
            // 
            this.AdditionalButtonLayoutPanel = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                Location = new Point(0, 0),
                Margin = new Padding(3, 2, 3, 2),
                Name = "AdditionalButtonLayoutPanel",
                RowCount = 1,
            };

            // 
            // ViewMapButton
            // 
            this.ViewMapButton = new Button()
            {
                Cursor = Cursors.Hand,
                Dock = DockStyle.Fill,
                Enabled = false,
                Location = new Point(25, 25),
                Name = "ViewMapButton",
                Size = new Size(152, 38),
                TabIndex = 5,
                Text = "View on Map",
                UseVisualStyleBackColor = false,
            };

            // 
            // ShareByEmail
            // 
            this.ShareByEmail = new Button()
            {
                Cursor = Cursors.Hand,
                Dock = DockStyle.Fill,
                Enabled = false,
                Location = new Point(25, 25),
                Name = "ShareByEmail",
                Size = new Size(152, 38),
                TabIndex = 5,
                Text = "Send via Email",
                UseVisualStyleBackColor = false,

            };
            

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
            // connectionGrid
            // 
            this.ConnectionGrid = new DataGridView() {
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
                DisplayIndex = 0,
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
                DisplayIndex = 1,
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
                DisplayIndex = 2,
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
                DisplayIndex = 3,
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
                DisplayIndex = 4,
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
                DisplayIndex = 5,
            };

            //
            // Hidden Columns
            //
            this.ToCoord = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "ToStationCoord",
                HeaderText = "ToCoord",
                Name = "ToCoord",
                ReadOnly = true,
                Visible = false,
            };
            this.FromCoord = new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "FromStationCoord",
                HeaderText = "FromCoord",
                Name = "FromCoord",
                ReadOnly = true,
                Visible = false,
            };

            // Adding Elements to Containers
            this.TimetableTab.Controls.Add(this.SplitContainer1);
            this.SplitContainer1.Panel1.Controls.Add(this.TableLayoutPanel1);
            this.SplitContainer1.Panel2.Controls.Add(this.ConnectionGrid);

            this.AdditionalButtonLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.AdditionalButtonLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.AdditionalButtonLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.AdditionalButtonLayoutPanel.Controls.Add(this.ViewMapButton);
            this.AdditionalButtonLayoutPanel.Controls.Add(this.ShareByEmail);

            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            this.TableLayoutPanel1.Controls.Add(this.FromLabel, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.FromBox.SearchBox, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.ToLabel, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.ToBox.SearchBox, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.ViaBox.SearchBox, 1, 2);
            this.TableLayoutPanel1.Controls.Add(this.ViaLabel, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.DateLabel, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.TimeLabel, 2, 1);
            this.TableLayoutPanel1.Controls.Add(this.DatePicker, 3, 0);
            this.TableLayoutPanel1.Controls.Add(this.TimePicker, 3, 1);
            this.TableLayoutPanel1.Controls.Add(this.AdditionalButtonLayoutPanel, 3, 2);
            this.TableLayoutPanel1.Controls.Add(this.SearchButton, 4, 2);


            this.ConnectionGrid.Columns.AddRange(new DataGridViewColumn[] {
                this.FromStation,
                this.ToStation,
                this.FromStationDepartureTime,
                this.ToStationArrivalTime,
                this.Duration,
                this.Delay,
                this.FromCoord,
                this.ToCoord,
            });

            // Last so they're on top
            this.TimetableTab.Controls.Add(this.FromBox.AutoSuggestList);
            this.TimetableTab.Controls.Add(this.ToBox.AutoSuggestList);
            this.TimetableTab.Controls.Add(this.ViaBox.AutoSuggestList);

            // Initializing Event Handlers
            this.TimetableTab.Paint += new PaintEventHandler(this.TimetableTab_Paint);
            this.SearchButton.Click += new EventHandler(this.SearchButton_Click);
            this.FromBox.SearchBox.TextChanged += new EventHandler(this.CheckFields_Completion);
            this.ToBox.SearchBox.TextChanged += new EventHandler(this.CheckFields_Completion);
            this.ViaBox.SearchBox.TextChanged += new EventHandler(this.ViaBox_TextChanged);
            this.ViaBox.SearchBox.TextChanged += new EventHandler(this.CheckFields_Completion);
            this.DatePicker.ValueChanged += new EventHandler(this.DatePicker_ValueChange);
            this.TimePicker.ValueChanged += new EventHandler(this.TimePicker_ValueChange);
            this.ShareByEmail.Click += new EventHandler(this.EmailConnection);
            this.ViewMapButton.Click += new EventHandler(this.ViewMapButton_Click);
            this.ConnectionGrid.SelectionChanged += new EventHandler(this.ConnectionGrid_SelectionChange);
        }

        private void ViaBox_TextChanged(object? sender, EventArgs e)
        {
            if (ViaBox.SearchBox.Text.Length > 1)
            {
                ViaBoxFilledOut = true;
            } else
            {
                ViaBoxFilledOut = false;
            }
        }

        private void ViewMapButton_Click(object? sender, EventArgs e)
        {
            MapDialog.AddRoute(SelectedConnection);
            MapDialog.Show();
        }

        private void ConnectionGrid_SelectionChange(object? sender, EventArgs e)
        {
            if (ConnectionGrid.Rows.Count > 0)
            {
                SelectedConnection = ConnectionController.Connections[ConnectionGrid.SelectedRows[0].Index];
                this.ShareByEmail.Enabled = true;
                this.ViewMapButton.Enabled = true;
            } else
            {
                SelectedConnection = null;
                this.ShareByEmail.Enabled = false;
                this.ViewMapButton.Enabled = false;
            }
        }

        private void EmailConnection(object? sender, EventArgs e)
        {
            Form emailDialog = new EmailDialog("Please enter the name and email address of the recipient.", "Name",
                "Email Address");

            if (emailDialog.ShowDialog() == DialogResult.OK)
            {
                MailboxAddress receiverAddress = (MailboxAddress) emailDialog.Tag;
                
                EmailSendingController.ConstructEmail(receiverAddress, SelectedConnection.FromStation,
                    SelectedConnection.FromStationDepartureTime.ToString(), SelectedConnection.ToStation,
                    SelectedConnection.ToStationArrivalTime.ToString());

                if (EmailSendingController.SendMail())
                {
                    MessageBox.Show($"Successfully sent Email to {receiverAddress.Address}");
                }
                else
                {
                    MessageBox.Show("An error has occurred while trying to send email.");
                }
            }
        }

        private void TimePicker_ValueChange(object? sender, EventArgs e)
        {
            TimePickerFilledOut = true;
        }

        private void DatePicker_ValueChange(object? sender, EventArgs e)
        {
            DatePickerFilledOut = true;
        }

        private void CheckFields_Completion(object? sender, EventArgs e)
        {
            // Enable Search Button, if from and to filled out
            if (RegexHelper.IsValidSearchQuery(this.FromBox.SearchBox.Text) == true
                && RegexHelper.IsValidSearchQuery(this.ToBox.SearchBox.Text) == true
                && ( ViaBoxFilledOut == true || RegexHelper.IsValidSearchQuery(this.ViaBox.SearchBox.Text) == false))
            {
                this.SearchButton.Enabled = true;
            } else
            {
                this.SearchButton.Enabled = false;
            }
        }

        private void SearchButton_Click(object? sender, EventArgs e)
        {
            try
            { 
                if (this.TimePickerFilledOut && this.DatePickerFilledOut && RegexHelper.IsValidSearchQuery(this.FromBox.SelectedStation.Name) && RegexHelper.IsValidSearchQuery(this.ToBox.SelectedStation.Name))
                {
                    ConnectionController.GetConnections(FromBox.SelectedStation.Name, ToBox.SelectedStation.Name, DatePicker.Value, TimePicker.Value, ViaBoxFilledOut ? ViaBox.SelectedStation.Name : null);
                }
                else if (RegexHelper.IsValidSearchQuery(this.FromBox.SelectedStation.Name) && RegexHelper.IsValidSearchQuery(this.ToBox.SelectedStation.Name))
                {
                    ConnectionController.GetConnections(FromBox.SelectedStation.Name, ToBox.SelectedStation.Name, 
                        (ViaBoxFilledOut && RegexHelper.IsValidSearchQuery(ViaBox.SelectedStation.Name) ? ViaBox.SelectedStation.Name : null));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to get connection. Error occurred: {ex.Message}");
            } 
        }

        private void TimetableTab_Paint(object sender, PaintEventArgs e)
        {
            this.FromBox.SearchBox.Focus();
            AdjustColumnOrder();
        }

        private void AdjustColumnOrder()
        {
            ConnectionGrid.Columns["FromStation"].DisplayIndex = 0;
            ConnectionGrid.Columns["FromStationDepartureTime"].DisplayIndex = 1;
            ConnectionGrid.Columns["ToStation"].DisplayIndex = 2;
            ConnectionGrid.Columns["ToStationArrivalTime"].DisplayIndex = 3;
            ConnectionGrid.Columns["Duration"].DisplayIndex = 4;
            ConnectionGrid.Columns["Delay"].DisplayIndex=5;
        }
    }
}
