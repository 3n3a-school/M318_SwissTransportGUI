using System.Runtime.InteropServices;
using SwissTransportGUI.Controller;
using SwissTransportGUI.View.Controller;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SwissTransportGUI.View;

public partial class MainWindow : Form
{
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();

    private ConnectionSearchController ConnectionController { get; set; }
    private StationTableTabView StationTableTabView { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        StationTableTabView = new StationTableTabView();
        TabControl.TabPages.Add(StationTableTabView.StationTableTab);

        AllocConsole();

        Text = "Swiss Transport"; // Title

        // Connection
        ConnectionController = new ConnectionSearchController();
        connectionGrid.DataSource = ConnectionController.Connections;
        ConnectionController.GetConnections("Luzern", "Zürich");
    }

    private void TabControl_Selected(object sender, TabControlEventArgs e)
    {

    }

    private void TimetableTab_Paint(object sender, PaintEventArgs e)
    {
        
    }
}