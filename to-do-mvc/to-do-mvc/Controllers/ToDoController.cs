using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using to_do_mvc.Data;
using to_do_mvc.Dtos;
using to_do_mvc.Models;

namespace to_do_mvc.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoRepo _repository;
        private readonly IMapper _mapper;

        [BindProperty]
        public ToDo toDo { get; set; }

        public ToDoController(IToDoRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all to dos.
        /// Loads view with all to dos.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var toDos = await _repository.GetAllToDos();
            return View(_mapper.Map<IEnumerable<ToDoReadDto>>(toDos));
        }

        /// <summary>
        /// Displays privacy page
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Calls action to create new to do.
        /// Redirects to page with all to dos.
        /// </summary>
        /// <param name="toDoCreateDto"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoCreateDto toDoCreateDto)
        {
            if (ModelState.IsValid)
            {
                ToDo toDoModel = _mapper.Map<ToDo>(toDoCreateDto);
                await _repository.CreateToDo(toDoModel);
                return Redirect("/ToDo");
            }
            return Redirect("/ToDo");
        }

        /// <summary>
        /// Calls action to update to do.
        /// Redirects to page with all to dos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id)
        {
            bool response = await _repository.UpdateToDo(id);
            if (response == false)
                return NotFound();
            return Redirect("/ToDo");
        }

        /// <summary>
        /// Calls action to delete to do.
        /// Redirects to page with all to dos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _repository.DeleteToDo(id);
            if (response == false)
                return NotFound();
            return Redirect("/ToDo");
        }

    }
}
