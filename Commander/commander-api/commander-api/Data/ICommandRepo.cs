using commander_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace commander_api.Data
{
    public interface ICommandRepo
    {
        Task<int> SaveChanges();
        Task<IEnumerable<Command>> GetAllCommands();
        Task<Command> GetCommand(int id);
        Task CreateCommand(Command command);
        Task DeleteCommand(Command command);
    }
}
