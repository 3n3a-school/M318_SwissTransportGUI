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
            this.StationsNearbyTab = new System.Windows.Forms.TabPage();
            
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // StationsNearbyTab
            // 
            this.StationsNearbyTab.BackColor = System.Drawing.Color.White;
            this.StationsNearbyTab.Location = new System.Drawing.Point(4, 24);
            this.StationsNearbyTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StationsNearbyTab.Name = "StationsNearbyTab";
            this.StationsNearbyTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StationsNearbyTab.Size = new System.Drawing.Size(692, 310);
            this.StationsNearbyTab.TabIndex = 1;
            this.StationsNearbyTab.Text = "Stations Nearby";
            
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.StationsNearbyTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(700, 338);
            this.TabControl.TabIndex = 0;
            this.TabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl_Selected);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.TabControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Swiss Transport";
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl TabControl;
        private TabPage StationsNearbyTab;
        
    }
}