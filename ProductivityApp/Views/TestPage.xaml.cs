using Microsoft.Maui.Controls;
using ProductivityApp.Data;
using ProductivityApp.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace ProductivityApp.Views
{
    
    public partial class TestPage : ContentPage
    {
        private readonly ChartDatabase _chartDatabase;
        public ObservableCollection<TaskItem> TaskItems { get; set; }

        public TestPage()
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
            App.Database.SaveChartDataModelAsync(new TaskItem
            {
                Name ="test1",
                Date= DateTime.Parse("2022-02-03"),
                Priority = "2",
                Done = true,
            });

            Console.WriteLine("GetFolderPath: {0}",
                 Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Database.DeleteRecordById(Id);

        }
    }
}
