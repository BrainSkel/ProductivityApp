
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductivityApp.Models
{
    internal class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public Date Date { get; set; }
        public bool Done { get; set; }

    }
}
