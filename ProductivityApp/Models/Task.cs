﻿
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
        public string Priority { get; set; }
        public string? Date { get; set; }
        public bool Done { get; set; }

    }
}
