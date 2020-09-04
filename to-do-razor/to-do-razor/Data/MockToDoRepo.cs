using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using to_do_razor.Models;

namespace to_do_razor.Data
{
    public class MockToDoRepo : IToDoRepo
    {
        public Task AddToDo(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteToDo(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ToDo>> GetAllToDos()
        {
            var toDo = new List<ToDo>
            {
               new ToDo{Id=1, ToDoText="task 1", IsCompleted=false},
               new ToDo{Id=2, ToDoText="task 2", IsCompleted=true},
               new ToDo{Id=3, ToDoText="task 3", IsCompleted=true},
               new ToDo{Id=4, ToDoText="task 4", IsCompleted=false},
            };

            return toDo;
        }

        public Task<bool> UpdateToDo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
