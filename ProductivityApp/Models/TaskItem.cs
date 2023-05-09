
using SQLite;
using System.ComponentModel.DataAnnotations;

namespace ProductivityApp.Models
{
    public class TaskItem
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        [Display(Name= "Task Name")]
        public string Name { get; set; }
        [Display(Name = "Priority")]
        public string Priority { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Completed?")]
        public bool Done { get; set; }

    }
}
