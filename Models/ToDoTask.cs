using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laborator1.Models
{

    public class ToDoTask
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
        
        [Required]
        public DateTime AddedAt { get; set; }
        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        [Range(0, 2)]
        public ImportanceEnum Importance {get; set;}
        [Required]
        [Range(0, 2)]
        public StatusEnum Status {get; set;}
        
        public DateTime ClosedAt { get; set; }
          

    }
}
