using System.Net;
using System.Runtime.InteropServices;
using SwissTransportGUI.Controller;

namespace SwissTransportGUI.View;

public partial class MainWindow : Form
{
   //[DllImport("kernel32.dll", SetLastError = true)]
   //[return: MarshalAs(UnmanagedType.Bool)]
   //static extern bool AllocConsole();

    private StationTableTabView StationTableTabView { get; set; }
    private TimetableTabView TimetableTabView { get; set;}
    private StationsNearbyView StationsNearbyView { get; set;}

    public MainWindow()
    {
        InitializeComponent();
        
        StationTableTabView = new StationTableTabView();
        TimetableTabView = new TimetableTabView();
        StationsNearbyView = new StationsNearbyView();

        TabControl.TabPages.AddRange(new TabPage[] {
            TimetableTabView.TimetableTab,
            StationsNearbyView.StationsNearbyTab,
            StationTableTabView.StationTableTab,
        });

        //AllocConsole();
    }

    private void CheckInternetconnection()
    {
        if (!RegexHelper.IsConnectedToInternet())
        {
            DialogResult r = MessageBox.Show("You appear to be disconnected from the wonders of the web. This application is in need of such a connection to function correctly.", "No active internet connection", MessageBoxButtons.RetryCancel);
            if (r == DialogResult.Cancel)
            {
                Close();
            }
            else if (r == DialogResult.Retry)
            {
                MainWindow_Load(new object(), new EventArgs());
            }
        }
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        CheckInternetconnection();
    }
}