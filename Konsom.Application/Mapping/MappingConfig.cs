using AutoMapper;
using Konsom.Application.CommandAndQuery.Notes.Queries.GetNotes;
using Konsom.Application.Models.Dto;
using Konsom.Domain;

namespace Konsom.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Note, NoteDTO>().ReverseMap();
            CreateMap<Note, NoteCreateDTO>().ReverseMap();
            CreateMap<Note, NoteUpdateDTO>().ReverseMap();

            CreateMap<Reminder, ReminderDTO>().ReverseMap();
            CreateMap<Reminder, ReminderCreateDTO>().ReverseMap();
            CreateMap<Reminder, ReminderUpdateDTO>().ReverseMap();

            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<Tag, TagCreateDTO>().ReverseMap();
            CreateMap<Tag, TagUpdateDTO>().ReverseMap();
        }
    }
}
