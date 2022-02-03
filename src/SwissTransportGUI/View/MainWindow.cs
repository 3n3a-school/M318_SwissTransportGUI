using System.Runtime.InteropServices;
using SwissTransportGUI.View.Controller;

namespace SwissTransportGUI.View;

public partial class MainWindow : Form
{
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();

    public MainWindow()
    {
        InitializeComponent();
        AllocConsole();

        Text = "Swiss Transport"; // Title
        StationTableController = new StationTableController();

        // Stationtable Search Box
        SearchBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
        SearchBox.AutoCompleteMode = AutoCompleteMode.Suggest;
        SearchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

        // Stationtable GridView
        stationTableGrid.DataSource = StationTableController.StationBoardEntries;
    }

    private StationTableController StationTableController { get; }

    private void SearchButton_Click(object sender, EventArgs e)
    {
        string stationNameQuery = SearchBox.Text;
        if (string.IsNullOrWhiteSpace(stationNameQuery) == false)
        {
            StationTableController.GetStationBoard(stationNameQuery);
        }
    }

    private void SearchBox_KeyUp(object sender, KeyEventArgs e)
    {
        

    }

    private void SearchBox_TextChanged(object sender, EventArgs e)
    {
        string stationNameQuery = SearchBox.Text; // TODO: check is string
        if (string.IsNullOrWhiteSpace(stationNameQuery) == false)
        {
            AutoCompleteStringCollection searchStringCollection = StationTableController.GetStationSuggestions(stationNameQuery);
            SearchBox.AutoCompleteCustomSource = searchStringCollection;
        }
    }
}