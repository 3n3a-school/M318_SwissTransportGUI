using System.Runtime.InteropServices;

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
            TimetableTabView.TimetableTab,
            StationTableTabView.StationTableTab,
        });

        AllocConsole();
    }

    private void TabControl_Selected(object sender, TabControlEventArgs e)
    {

    }
}