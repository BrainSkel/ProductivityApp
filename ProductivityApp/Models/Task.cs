using Android.Telecom;
using Java.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityApp.Models
{
    internal class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Date StartDate { get; set; }
        public Timespan Duration { get; set; }

    }
}
