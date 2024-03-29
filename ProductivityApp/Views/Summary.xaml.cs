using Microsoft.Maui.Controls;
using ProductivityApp.Data;
using ProductivityApp.Models;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace ProductivityApp.Views
{
    public partial class Summary : ContentPage
    {
        private readonly ChartDatabase _chartDatabase;
        public ObservableCollection<TaskItem> TaskItems { get; set; }
        public Summary()
        {
            InitializeComponent();

            // Get the path of the SQLite database file
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ChartDataBase.db3");

            // Create an instance of the ChartDatabase class
            _chartDatabase = new ChartDatabase(dbPath);

            // Initialize the ObservableCollection with the data from the TaskItem SQLite table
            TaskItems = new ObservableCollection<TaskItem>(_chartDatabase.GetChartDataModel());

            // Bind the TaskItems collection to the ListView control
            //MyListView.ItemsSource = TaskItems;
        }

        //private void MarkAsDoneButton_Clicked(object sender, EventArgs e)
        //{
        //    var selectedItem = MyListView.SelectedItem as TaskItem;
        //    if (selectedItem != null)
        //    {
        //        selectedItem.Done = true;
        //        _chartDatabase.SaveChartDataModelAsync(selectedItem);
        //    }
        //}

        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            var taskItem = new TaskItem
            {
                Name = TaskName.Text,
                Date = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd")),
                Priority = PriorityPicker.SelectedItem != null ? PriorityPicker.SelectedItem.ToString() : string.Empty,
                Done = false,
            };
            TaskItems.Add(taskItem);
            _chartDatabase.SaveChartDataModelAsync(taskItem);
            Application.Current.MainPage = new NavigationPage(new MainPage());

        }

        //private void DeleteButton_Clicked(object sender, EventArgs e)
        //{
        //    var selectedItem = MyListView.SelectedItem as TaskItem;
        //    if (selectedItem != null)
        //    {
        //        TaskItems.Remove(selectedItem);
        //        _chartDatabase.DeleteRecordById(selectedItem.Id);
        //    }
        //}
        public void HomeButton_Clicked(System.Object sender, System.EventArgs e)
            => Application.Current.MainPage = new NavigationPage(new MainPage());

        public void SearchButton_Clicked(System.Object sender, System.EventArgs e)
            => Application.Current.MainPage = new NavigationPage(new Search());

        public void SummaryButton_Clicked(System.Object sender, System.EventArgs e)
            => Application.Current.MainPage = new NavigationPage(new Summary());
    }
}