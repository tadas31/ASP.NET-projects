using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using to_do_razor.Models;

namespace to_do_razor.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> opt) : base(opt)
        {

        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
