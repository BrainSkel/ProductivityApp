using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityApp.Models;

namespace ProductivityApp.Data
{
    public class ChartDatabase
    {
        readonly SQLiteConnection _database;

        public ChartDatabase(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<TaskItem>();
        }

        //Get the list of ChartDataModel items from the database
        public List<TaskItem> GetChartDataModel()
        {
            return _database.Table<TaskItem>().ToList();
        }

        //Insert an item in the database
        public int SaveChartDataModelAsync(TaskItem chartDataModel)
        {
            if (chartDataModel == null)
            {
                throw new Exception("Null");
            }

            return _database.Insert(chartDataModel);
        }

        //Delete an item in the database 
        public int DeleteChartDataModelAsync(TaskItem chartDataModel)
        {
            return _database.Delete(chartDataModel);
        }
    }
}
