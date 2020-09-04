using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using to_do_razor.Models;

namespace to_do_razor.Data
{
    public interface IToDoRepo
    {
        Task<IEnumerable<ToDo>> GetAllToDos();
        Task AddToDo(ToDo toDo);
        Task<bool> UpdateToDo(int id);
        Task<bool> DeleteToDo(int id);
    }
}
