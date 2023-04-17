namespace Productivity_App.Models
{
    public class Tasks
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; } 



    }
}
