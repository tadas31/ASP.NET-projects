using System.ComponentModel.DataAnnotations;

namespace to_do_mvc.Dtos
{
    public class ToDoCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
