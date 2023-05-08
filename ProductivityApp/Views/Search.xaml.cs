

using ProductivityApp.Data;
using ProductivityApp.Models;
using SQLite;
using System.Collections.ObjectModel;

namespace ProductivityApp.Views;

public partial class Search : ContentPage
{
    private readonly ChartDatabase _chartDatabase;
    public ObservableCollection<TaskItem> TaskItems { get; set; }
    SearchBar searchBar = new SearchBar { Placeholder = "Search items..." };
    public Search()
    {
        InitializeComponent();

        // Get the path of the SQLite database file
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ChartDataBase.db3");

        // Create an instance of the ChartDatabase class
        _chartDatabase = new ChartDatabase(dbPath);

        // Initialize the ObservableCollection with the data from the TaskItem SQLite table
        TaskItems = new ObservableCollection<TaskItem>(_chartDatabase.GetChartDataModel());

        // Bind the TaskItems collection to the ListView control
        MyListView.ItemsSource = TaskItems;
    }



   
    private void Button_Clicked(object sender, EventArgs e)
    {
        //// Get the selected TaskItem
        //TaskItem selectedTaskItem = MyListView.SelectedItem as TaskItem;

        //// Make sure a TaskItem was selected
        //if (selectedTaskItem == null)
        //{
        //    return;
        //}

        //// Delete the selected TaskItem from the database
        //await App.Database.DeleteAsync(selectedTaskItem);

        //// Remove the selected TaskItem from the TaskItems collection
        //TaskItems.Remove(selectedTaskItem);
        App.Database.DeleteRecordById(1);
    }


}

