using ProductivityApp.Data;

namespace ProductivityApp;

public partial class App : Application
{
    static ChartDatabase database;
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
    public static ChartDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new ChartDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ChartDataBase.db3"));

            }
            return database;
        }
    }
}

