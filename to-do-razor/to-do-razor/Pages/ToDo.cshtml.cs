using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using to_do_razor.Data;
using to_do_razor.Models;

namespace to_do_razor.Pages
{

    public class ToDoModel : PageModel
    {

        private readonly IToDoRepo _repository;

        public IEnumerable<ToDo> ToDos { get; set; }

        [BindProperty]
        public ToDo ToDo { get; set; }

        public ToDoModel(IToDoRepo repository)
        {
            _repository = repository;
        }

        public async Task OnGet()
        {
            ToDos = await _repository.GetAllToDos();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ToDo.IsCompleted = false;
                await _repository.AddToDo(ToDo);
            }
            return Redirect("/ToDo");
        }

        public async Task<IActionResult> OnPostUpdate(int id)
        {
            bool result = await _repository.UpdateToDo(id);
            if (result == false)
                return NotFound();
            return Redirect("/ToDo");
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            bool result = await _repository.DeleteToDo(id);
            if (result == false)
                return NotFound();

            return Redirect("/ToDo");
        }
    }
}