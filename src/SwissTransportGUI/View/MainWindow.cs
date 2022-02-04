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

    private StationTableTabView StationTableTabView { get; set; }
    private TimetableTabView TimetableTabView { get; set;}

    public MainWindow()
    {
        InitializeComponent();
        StationTableTabView = new StationTableTabView();
        TimetableTabView = new TimetableTabView();
        TabControl.TabPages.AddRange(new TabPage[] {
            StationTableTabView.StationTableTab,
            TimetableTabView.TimetableTab,
        });

        AllocConsole();
    }

    private void TabControl_Selected(object sender, TabControlEventArgs e)
    {

    }
}