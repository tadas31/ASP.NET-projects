using AutoMapper;
using to_do_mvc.Dtos;
using to_do_mvc.Models;

namespace to_do_mvc.Profiles
{
    public class ToDosProfile : Profile
    {
        public ToDosProfile()
        {
            CreateMap<ToDo, ToDoReadDto>();
            CreateMap<ToDoCreateDto, ToDo>();
        }
    }
}
