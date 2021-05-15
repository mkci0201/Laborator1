using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laborator1.Models
{

    public class ToDoTask
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "{0} length must be between {3} and {1}", MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(50, ErrorMessage ="{0} should not exceed {1} characters")]
        public string Description { get; set; }
        
        [Required]
        [Display(Name = "Task Added on")]
        public DateTime AddedAt { get; set; }
        [Required]
        [Display(Name = "Deadline")]
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
