namespace SwissTransportGUI.View
{
    partial class EmailDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DialogQuestion = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.InputLabel1 = new System.Windows.Forms.Label();
            this.InputField1 = new System.Windows.Forms.TextBox();
            this.InputLabel2 = new System.Windows.Forms.Label();
            this.InputField2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DialogQuestion
            // 
            this.DialogQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DialogQuestion.AutoSize = true;
            this.DialogQuestion.Location = new System.Drawing.Point(3, 52);
            this.DialogQuestion.Name = "DialogQuestion";
            this.DialogQuestion.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.DialogQuestion.Size = new System.Drawing.Size(562, 20);
            this.DialogQuestion.TabIndex = 1;
            this.DialogQuestion.Text = "label1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.DialogQuestion, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(568, 125);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // InputLabel1
            // 
            this.InputLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.InputLabel1.AutoSize = true;
            this.InputLabel1.Location = new System.Drawing.Point(194, 28);
            this.InputLabel1.Name = "InputLabel1";
            this.InputLabel1.Size = new System.Drawing.Size(87, 20);
            this.InputLabel1.TabIndex = 5;
            this.InputLabel1.Text = "InputLabel1";
            // 
            // InputField1
            // 
            this.InputField1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.InputField1.Location = new System.Drawing.Point(287, 25);
            this.InputField1.Name = "InputField1";
            this.InputField1.Size = new System.Drawing.Size(125, 27);
            this.InputField1.TabIndex = 4;
            this.InputField1.TextChanged += new System.EventHandler(this.InputField1_TextChanged);
            // 
            // InputLabel2
            // 
            this.InputLabel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.InputLabel2.AutoSize = true;
            this.InputLabel2.Location = new System.Drawing.Point(231, 105);
            this.InputLabel2.Name = "InputLabel2";
            this.InputLabel2.Size = new System.Drawing.Size(50, 20);
            this.InputLabel2.TabIndex = 7;
            this.InputLabel2.Text = "label1";
            // 
            // InputField2
            // 
            this.InputField2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.InputField2.Location = new System.Drawing.Point(287, 102);
            this.InputField2.Name = "InputField2";
            this.InputField2.Size = new System.Drawing.Size(125, 27);
            this.InputField2.TabIndex = 6;
            this.InputField2.TextChanged += new System.EventHandler(this.InputField2_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.InputLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.InputField2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.InputLabel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.InputField1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 125);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(568, 154);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ContinueButton);
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Location = new System.Drawing.Point(324, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 82);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // ContinueButton
            // 
            this.ContinueButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ContinueButton.Enabled = false;
            this.ContinueButton.Location = new System.Drawing.Point(125, 45);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(94, 29);
            this.ContinueButton.TabIndex = 12;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(25, 45);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 29);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            // 
            // EmailDialog
            // 
            this.AcceptButton = this.ContinueButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(568, 385);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EmailDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EmailDialog";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label DialogQuestion;
        private TableLayoutPanel tableLayoutPanel1;
        private Label InputLabel1;
        private TextBox InputField1;
        private Label InputLabel2;
        private TextBox InputField2;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox1;
        private Button ContinueButton;
        private Button CancelButton;
    }
}