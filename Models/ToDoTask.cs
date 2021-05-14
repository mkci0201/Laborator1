﻿using System;
using System.Collections.Generic;

namespace Laborator1.Models
{

    public class ToDoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime Deadline { get; set; }
        public ImportanceEnum Importance {get; set;}
        public StatusEnum Status {get; set;}
        public DateTime ClosedAt { get; set; }
          

    }
}
