using SQLite;

namespace ProductivityApp.Models
{
    public class TaskItem
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public string Date { get; set; }
        public bool Done { get; set; }

    }
}
