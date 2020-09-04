using Microsoft.EntityFrameworkCore;
using to_do_mvc.Models;

namespace to_do_mvc.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> opt) : base(opt)
        {

        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
