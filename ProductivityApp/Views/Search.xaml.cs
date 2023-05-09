

using ProductivityApp.Data;
using ProductivityApp.Models;
using SQLite;
using System.Collections.ObjectModel;

namespace ProductivityApp.Views;

public partial class Search : ContentPage
{
    private readonly ChartDatabase _chartDatabase;
    public ObservableCollection<TaskItem> TaskItems { get; set; }
    private SearchBar _searchBar = new SearchBar { Placeholder = "Search items..." };
    private Grid _Navigation = new Grid();
    private String query = "";
    public Search()
    {
        InitializeComponent();
        _Navigation = Navigation;

        // Get the path of the SQLite database file
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ChartDataBase.db3");

        // Create an instance of the ChartDatabase class
        _chartDatabase = new ChartDatabase(dbPath);

        // Initialize the TaskItems collection with the data from the TaskItem SQLite table
        TaskItems = new ObservableCollection<TaskItem>(_chartDatabase.GetChartDataModel());

        // Bind the TaskItems collection to the ListView control
        MyListView.ItemsSource = TaskItems;


        // Add the ListView and SearchBar to the layout
        var stackLayout = new StackLayout();
        stackLayout.Children.Add(_searchBar);
        stackLayout.Children.Add(MyListView);
        stackLayout.Children.Add(_Navigation);
        OnSearchBarTextChanged(this, new TextChangedEventArgs("", ""));
        Content = stackLayout;
        // Attach event handlers
        _searchBar.TextChanged += OnSearchBarTextChanged;

    }


    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        query = e.NewTextValue;
        TaskItems.Clear();

        if (string.IsNullOrEmpty(query))
        {
            // Reset the TaskItems collection to show all items
            MyListView.ItemsSource = TaskItems;
            var Itemss = _chartDatabase.GetChartDataModel();

            foreach (var item in Itemss)
            {
                TaskItems.Add(item);
            }

        }
        else
        {
            // Filter the TaskItems collection based on the search query
            var filteredItems = _chartDatabase.GetChartDataModel().Where(item =>
                item.Name.Contains(query, StringComparison.OrdinalIgnoreCase));

            TaskItems.Clear();

            foreach (var item in filteredItems)
            {
                TaskItems.Add(item);
            }
        }
        MyListView.ItemsSource = TaskItems;
    }




    private void Button_Clicked(object sender, EventArgs e)
    {
        // Get the selected TaskItem
        TaskItem selectedTaskItem = MyListView.SelectedItem as TaskItem;

        // Make sure a TaskItem was selected
        if (selectedTaskItem == null)
        {
            return;
        }

        // Delete the selected TaskItem from the database
        //await App.Database.DeleteAsync(selectedTaskItem);

        // Remove the selected TaskItem from the TaskItems collection
        TaskItems.Remove(selectedTaskItem);
        App.Database.DeleteRecordById(selectedTaskItem.Id);
    }
    public void HomeButton_Clicked(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new MainPage());

    public void SearchButton_Clicked(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new Search());

    public void SummaryButton_Clicked(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new Summary());



    private void TestPage(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new TestPage());


}
