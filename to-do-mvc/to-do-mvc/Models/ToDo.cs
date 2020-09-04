using System;
using System.ComponentModel.DataAnnotations;

namespace to_do_mvc.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
