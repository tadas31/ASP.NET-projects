using System.Collections.Generic;
using System.Threading.Tasks;
using to_do_mvc.Models;

namespace to_do_mvc.Data
{
    public interface IToDoRepo
    {
        Task<IEnumerable<ToDo>> GetAllToDos();
        Task<bool> CreateToDo(ToDo todo);
        Task<bool> UpdateToDo(int id);
        Task<bool> DeleteToDo(int id);
    }
}
