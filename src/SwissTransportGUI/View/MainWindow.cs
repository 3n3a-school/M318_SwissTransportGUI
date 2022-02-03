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

    private StationTableController StationTableController { get; }
    private StationSearch StationSearcher { get; set; }

    private ConnectionSearchController ConnectionController { get; set; }

    private string LastProcessedSearchInput { get; set; } = "";

    public MainWindow()
    {
        InitializeComponent();
        AllocConsole();

        Text = "Swiss Transport"; // Title
        StationSearcher = new StationSearch();


        // Connection
        ConnectionController = new ConnectionSearchController();
        connectionGrid.DataSource = ConnectionController.Connections;
        ConnectionController.GetConnections("Luzern", "Zürich");

        // Stationtable
        StationTableController = new StationTableController();

        // Stationtable Search Box
        SearchBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
        SearchBox.AutoCompleteMode = AutoCompleteMode.Suggest;
        SearchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

        // Stationtable GridView
        stationTableGrid.DataSource = StationTableController.StationBoardEntries;
    }


    private void SearchButton_Click(object sender, EventArgs e)
    {
        string stationNameQuery = SearchBox.Text;
        if (string.IsNullOrWhiteSpace(stationNameQuery) == false)
        {
            StationTableController.GetStationBoard(stationNameQuery);
        }
    }

    private void SearchBox_TextChanged(object sender, EventArgs e)
    {
        // BUG: sometimes when letters are input very quickly -> crashes (Access Violation)
        string stationNameQuery = SearchBox.Text; // TODO: check is string

        if ((string.IsNullOrWhiteSpace(stationNameQuery) == false) && (LastProcessedSearchInput.Length < SearchBox.Text.Length))
        {
            Console.WriteLine("Updated AutoSuggestions");
            AutoCompleteStringCollection searchStringCollection = StationSearcher.GetStationSuggestions(stationNameQuery);
            lock (SearchBox.AutoCompleteCustomSource.SyncRoot)
            { 
                SearchBox.AutoCompleteCustomSource = searchStringCollection;
            }
        }
        LastProcessedSearchInput = stationNameQuery;
    }

    private void TabControl_Selected(object sender, TabControlEventArgs e)
    {

    }

    private void StationTableTab_Paint(object sender, PaintEventArgs e)
    {
        SearchBox.Focus();
    }

    private void SearchBoxClear_Click(object sender, EventArgs e)
    {
        SearchBox.Text = "";
    }

    private void TimetableTab_Paint(object sender, PaintEventArgs e)
    {
        
    }

    private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        

    }

    private void GetSearchSuggestions(object sender, EventArgs e)
    {
        
    }

    private void SearchBox_Enter(object sender, EventArgs e)
    {

    }

    private void SearchBox_Leave(object sender, EventArgs e)
    {

    }
}