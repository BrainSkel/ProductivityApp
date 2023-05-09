using Microsoft.Maui.Controls;
using ProductivityApp.Data;
using ProductivityApp.Models;
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
            MyListView.ItemsSource = TaskItems;
        }

        private void MarkAsDoneButton_Clicked(object sender, EventArgs e)
        {
            var selectedItem = MyListView.SelectedItem as TaskItem;
            if (selectedItem != null)
            {
                selectedItem.Done = true;
                _chartDatabase.SaveChartDataModelAsync(selectedItem);
            }
        }

        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            var taskItem = new TaskItem
            {
                Name = TaskName.Text,
                Date = DateTime.Parse("yyyy-MM-dd"),
                Priority = PriorityPicker.SelectedItem.ToString(),
                Done = false,
            };
            TaskItems.Add(taskItem);
            _chartDatabase.SaveChartDataModelAsync(taskItem);
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var selectedItem = MyListView.SelectedItem as TaskItem;
            if (selectedItem != null)
            {
                TaskItems.Remove(selectedItem);
                _chartDatabase.DeleteRecordById(selectedItem.Id);
            }
        }
    }
}