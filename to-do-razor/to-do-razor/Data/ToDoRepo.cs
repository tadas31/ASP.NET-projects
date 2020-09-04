using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using to_do_razor.Models;

namespace to_do_razor.Data
{
    public class ToDoRepo : IToDoRepo
    {
        private readonly ToDoContext _context;
        private readonly DbSet<ToDo> _ToDos;

        public ToDoRepo(ToDoContext context)
        {
            _context = context;
            _ToDos = _context.ToDos;
        }

        public async Task<IEnumerable<ToDo>> GetAllToDos()
        {
            var ToDos = await _ToDos.ToListAsync();
            return ToDos;
        }

        public async Task AddToDo(ToDo toDo)
        {
            await _ToDos.AddAsync(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateToDo(int id)
        {
            var ans = await _ToDos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ans is null)
                return false;

            ans.IsCompleted = !ans.IsCompleted;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteToDo(int id)
        {
            var ans = await _ToDos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ans is null)
                return false;

            _ToDos.Remove(ans);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
