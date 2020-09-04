using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace to_do_razor.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ToDoText { get; set; }

        [Required]
        public bool IsCompleted { get; set; }
    }
}
