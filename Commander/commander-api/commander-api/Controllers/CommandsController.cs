using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using commander_api.Data;
using commander_api.Dtos;
using commander_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace commander_api.Controllers
{
    [Route("api/command")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// GET api/command
        /// Gets all commands and returns them to user.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandReadDto>>> GetAllCommands()
        {
            IEnumerable<Command> commands = await _repository.GetAllCommands();
            if (commands.Count() < 1)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        /// <summary>
        /// GET api/command/{id}
        /// Gets command by id and returns it to user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetCommandById")]
        public async Task<ActionResult<CommandReadDto>> GetCommandById(int id)
        {
            Command command = await _repository.GetCommand(id);
            if (command == null)
                return NotFound();
            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        /// <summary>
        /// POST api/command
        /// Creates new command and returns it to user.
        /// </summary>
        /// <param name="commandCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CommandReadDto>> CreateCommand(CommandCreateDto commandCreateDto)
        {
            Command command = _mapper.Map<Command>(commandCreateDto);
            await _repository.CreateCommand(command);
            CommandReadDto commandReadDto = _mapper.Map<CommandReadDto>(command);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        /// <summary>
        /// PUT api/command/{id}
        /// Updates command and returns no content to user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commandUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            Command command = await _repository.GetCommand(id);
            if (command == null)
                return NotFound();

            _mapper.Map(commandUpdateDto, command);

            await _repository.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// DELETE api/command/{id}
        /// Deletes command and return no content or user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommand(int id)
        {
            Command command = await _repository.GetCommand(id);
            if (command == null)
                return NotFound();

            await _repository.DeleteCommand(command);
            return NoContent();
        }
    }
}
