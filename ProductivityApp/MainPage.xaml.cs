using ProductivityApp.Views;

namespace ProductivityApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
    }

    public void HomeButton_Clicked(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new MainPage());

	public void SearchButton_Clicked(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new Search());

	public void SummaryButton_Clicked(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new Summary());

	public void SeedData(System.Object sender, System.EventArgs e)
	{
		App.Database.SaveChartDataModelAsync( new Models.TaskItem
		{
			Name = "Test",
			Priority = "2",
			Done= true,
			Date="2023-05-03"
		});
			
	}

    private void TestPage(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new TestPage());
}

