using commander_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace commander_api.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly CommandContext _context;
        private readonly DbSet<Command> _commands;

        public CommandRepo(CommandContext context)
        {
            _context = context;
            _commands = _context.Commands;
        }

        /// <summary>
        /// Saves changes to db.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChanges()
        {
            int response = await _context.SaveChangesAsync();
            return response;
        }

        /// <summary>
        /// Gets all commands form db.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Command>> GetAllCommands()
        {
            IEnumerable<Command> commands = await _commands.ToListAsync();
            return commands;
        }

        /// <summary>
        /// Gets command from db by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Command> GetCommand(int id)
        {
            Command command = await _commands.Where(x => x.Id == id).FirstOrDefaultAsync();
            return command;
        }

        /// <summary>
        /// Creates new command in db.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task CreateCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            await _commands.AddAsync(command);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes command form db.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task DeleteCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            _commands.Remove(command);
            await _context.SaveChangesAsync();
        }
    }
}
