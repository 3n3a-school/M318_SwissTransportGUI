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
    }

    private StationTableController StationTableController { get; }

    private void SearchButton_Click(object sender, EventArgs e)
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

    private void SearchBox_KeyDown(object sender, KeyEventArgs e)
    {
        
    }
}