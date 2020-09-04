using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using to_do_mvc.Models;

namespace to_do_mvc.Data
{
    public class ToDoRepo : IToDoRepo
    {
        private readonly ToDoContext _context;
        private readonly DbSet<ToDo> _toDos;

        public ToDoRepo(ToDoContext context)
        {
            _context = context;
            _toDos = _context.ToDos;
        }

        /// <summary>
        /// Gets all to dos form database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ToDo>> GetAllToDos()
        {
            IEnumerable<ToDo> toDos = await _toDos.ToListAsync();
            return toDos;
        }

        /// <summary>
        /// Creates new to do in data base.
        /// </summary>
        /// <param name="todo">New to do to create.</param>
        /// <returns></returns>
        public async Task<bool> CreateToDo(ToDo todo)
        {
            todo.IsCompleted = false;
            todo.CreatedAt = DateTime.Now;
            await _toDos.AddAsync(todo);
            int response = await _context.SaveChangesAsync();

            return response > 0;
        }

        /// <summary>
        /// Changes completion value of selected to do.
        /// </summary>
        /// <param name="id">Id of selected to do.</param>
        /// <returns></returns>
        public async Task<bool> UpdateToDo(int id)
        {
            ToDo toDo = await _toDos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (toDo is null)
                return false;

            toDo.IsCompleted = !toDo.IsCompleted;
            int response = await _context.SaveChangesAsync();
            return response > 0;
        }

        /// <summary>
        /// Deletes selected to do.
        /// </summary>
        /// <param name="id">Id of selected to do.</param>
        /// <returns></returns>
        public async Task<bool> DeleteToDo(int id)
        {
            ToDo toDo = await _toDos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (toDo is null)
                return false;

            _toDos.Remove(toDo);
            int response = await _context.SaveChangesAsync();
            return response > 0;
        }
    }
}
