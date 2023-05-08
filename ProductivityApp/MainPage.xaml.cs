using ProductivityApp.Data;
using ProductivityApp.Models;
using ProductivityApp.Views;
using System.Collections.ObjectModel;

namespace ProductivityApp;

public partial class MainPage : ContentPage
{

    private readonly ChartDatabase _chartDatabase;
	public ObservableCollection<TaskItem> TaskItems { get; set; }


	public MainPage()
	{
		InitializeComponent();
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ChartDataBase.db3");

        _chartDatabase = new ChartDatabase(dbPath);
        List<TaskItem> chartData = _chartDatabase.GetChartDataModel().Take(5).ToList();
        TaskItems = new ObservableCollection<TaskItem>(chartData);

        MyListView.ItemsSource = TaskItems;
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

